using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Relatorios.GerarPdf
{
    public class GerarRelatorioPdfCommand : IRequest<byte[]>
    {
        public int Id { get; set; }

        public GerarRelatorioPdfCommand(int relatorioId)
        {
            Id = relatorioId;
        }
    }

}
