using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Update
{
    public class UpdateAnotacaoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        
    }
}
