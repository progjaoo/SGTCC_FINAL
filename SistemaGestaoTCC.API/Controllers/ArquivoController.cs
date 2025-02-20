using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using SistemaGestaoTCC.Application.Commands.Users.CreateUser;
using SistemaGestaoTCC.Application.Commands.Users.DeleteUser;
using SistemaGestaoTCC.Application.Commands.Users.LoginGoogle;
using SistemaGestaoTCC.Application.Commands.Users.LoginUser;
using SistemaGestaoTCC.Application.Commands.Users.UpdateUser;
using SistemaGestaoTCC.Application.Queries.Users.FindUsers;
using SistemaGestaoTCC.Application.Queries.Users.GetAllUserByRole;
using SistemaGestaoTCC.Application.Queries.Users.GetAllUsersByCourse;
using SistemaGestaoTCC.Application.Queries.Users.GetUser;
using SistemaGestaoTCC.Application.Queries.Users.GetUserByEmail;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using SistemaGestaoTCC.Application.Commands.Arquivos.Create;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/arquivos")]
    [ApiController]
    //[Authorize]
    public class ArquivoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ArquivoController(IMediator mediator)
        {
            _mediator = mediator;
        }

    
        [HttpGet("listarArquivos")]
        public async Task<IActionResult> GetAllFiles([FromQuery] FindUsersQuery query)
        {
            if (query.Papel != Core.Enums.PapelEnum.Aluno && query.Papel != PapelEnum.Professor)
            {
                return BadRequest("Papel inválido");
            }
            var listUsersRole = await _mediator.Send(query);

            return Ok(listUsersRole);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var filePath = Path.Combine(uploadDirectory, file.FileName);

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
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

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