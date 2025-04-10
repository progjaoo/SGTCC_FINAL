using MediatR;
using SistemaGestaoTCC.Application.ViewModels.TagsVM;

namespace SistemaGestaoTCC.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
        public TagsViewModel[] Tags { get; set; }
    }
}
