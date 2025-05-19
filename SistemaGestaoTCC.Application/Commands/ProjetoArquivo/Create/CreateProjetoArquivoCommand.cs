using MediatR;
using Microsoft.AspNetCore.Http;
using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Create
{
    public class CreateProjetoArquivoCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }
        public required IFormFile File { get; set; }
        public required string FolderName { get; set; }
    }
}
