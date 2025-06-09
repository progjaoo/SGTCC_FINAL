using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.IO;
using SistemaGestaoTCC.Application.Commands.Arquivos.Create;
using SistemaGestaoTCC.Application.Queries.Arquivos.GetAll;
using SistemaGestaoTCC.Infrastructure.Repositories;
using SistemaGestaoTCC.Application.Queries.Arquivos.Download;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/arquivos")]
    [ApiController]
    //[Authorize]
    public class ArquivoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string folderName;
        public ArquivoController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            folderName = configuration["Files:Directory"] ?? "UploadedFiles";
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            var arquivos = await _mediator.Send(new GetAllArquivoQuery());
            return Ok(arquivos);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Falha ao enviar arquivo.");
            }
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var command = new CreateArquivosCommand
            {
                File = file,
                Diretorio = uploadDirectory,
            };

            var id = await _mediator.Send(command);

            return Ok("Arquivo Criado");
        }

        [HttpGet("download/{idArquivo}")]
        public async Task<IActionResult> DownloadFileAsync(int idArquivo)
        {
            var arquivo = await _mediator.Send(new DownloadArquivoQuery { idArquivo = idArquivo });
            if (arquivo == null || string.IsNullOrEmpty(arquivo.Extensao))
                return NotFound("Arquivo não encontrado no banco de dados.");

            var nomeArquivo = $"{arquivo.Id}{arquivo.Extensao}";
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var filePath = Path.Combine(uploadDirectory, nomeArquivo);

            if (!System.IO.File.Exists(filePath))
                return NotFound("Arquivo não encontrado no disco.");

            var contentType = arquivo.Extensao switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };

            var nomeArquivoDownload = arquivo.NomeOriginal;

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                nomeArquivoDownload = nomeArquivoDownload.Replace(c, '_');
            }

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(stream, contentType, nomeArquivoDownload.Trim());
            /*
            var arquivo = await _mediator.Send(new DownloadArquivoQuery { idArquivo = idArquivo });

            var nomeArquivo = arquivo.Id.ToString() + arquivo.Extensao;

            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var filePath = Path.Combine(uploadDirectory, nomeArquivo);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Arquivo não Encontrado");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileExtension = arquivo.Extensao;
            string contentType = "application/octet-stream"; // Default MIME type

            // Set the appropriate content type based on the file extension
            if (fileExtension == ".jpg" || fileExtension == ".jpeg")
                contentType = "image/jpeg";
            else if (fileExtension == ".png")
                contentType = "image/png";
            else if (fileExtension == ".pdf")
                contentType = "application/pdf";

            Response.Headers.Append("Content-Disposition", $"attachment; filename={nomeArquivo}");

            // return File(fileBytes, contentType, nomeArquivo);
            */
        }
    }
}