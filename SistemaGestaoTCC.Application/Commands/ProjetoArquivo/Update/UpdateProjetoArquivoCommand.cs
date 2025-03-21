using MediatR;

namespace SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Update
{
    public class UpdateProjetoArquivoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
    }
}
