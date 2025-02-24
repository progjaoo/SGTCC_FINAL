using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using SistemaGestaoTCC.Application.Commands.Arquivos.Create;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.IO;
using SistemaGestaoTCC.Application.Queries.Arquivos.GetAll;

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
                NomeOriginal = file.FileName,
                Diretorio = folderName,
                Tamanho = (int)file.Length,
            };

            var id = await _mediator.Send(command);

            var extensao = Path.GetExtension(file.FileName);
            var novoNome = id.ToString() + extensao;

            var filePath = Path.Combine(uploadDirectory, novoNome);

            // Save the file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { FilePath = filePath });
        }

        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var filePath = Path.Combine(uploadDirectory, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileExtension = Path.GetExtension(fileName).ToLower();
            string contentType = "application/octet-stream"; // Default MIME type

            // Set the appropriate content type based on the file extension
            if (fileExtension == ".jpg" || fileExtension == ".jpeg")
                contentType = "image/jpeg";
            else if (fileExtension == ".png")
                contentType = "image/png";
            else if (fileExtension == ".pdf")
                contentType = "application/pdf";

            return File(fileBytes, contentType, fileName);
        }
    }
}