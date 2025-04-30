using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Relatorios.Update
{
    public class UpdateRelatorioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdProfessor { get; set; }
        public int IdProjeto { get; set; }
        public string? Titulo { get; set; }
        public string Descricao { get; set; }
        public int DuracaoEncontro { get; set; }
        public DateTime DataRealizacao { get; set; }
    }
}
