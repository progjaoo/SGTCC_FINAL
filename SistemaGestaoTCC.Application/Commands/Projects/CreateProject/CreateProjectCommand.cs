using MediatR;
using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Projects.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
        public FuncaoEnum Funcao { get; set; }
        public List<TagsViewModel> Tags { get; set; }
    }
}
