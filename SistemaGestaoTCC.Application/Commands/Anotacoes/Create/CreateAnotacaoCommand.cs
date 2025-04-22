using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Create
{
    public class CreateAnotacaoCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
