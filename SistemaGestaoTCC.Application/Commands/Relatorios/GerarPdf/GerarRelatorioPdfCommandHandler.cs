using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Relatorios.GerarPdf
{
    public class GerarRelatorioPDFCommandHandler : IRequestHandler<GerarRelatorioPdfCommand, byte[]>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioAcompanhamentoRepository;
        private readonly IRelatorioPDFGenerator _pdfGenerator;
        public GerarRelatorioPDFCommandHandler(IRelatorioAcompanhamentoRepository relatorioAcompanhamentoRepository, IRelatorioPDFGenerator pdfGenerator)
        {
            _relatorioAcompanhamentoRepository = relatorioAcompanhamentoRepository;
            _pdfGenerator = pdfGenerator;
        }

        public async Task<byte[]> Handle(GerarRelatorioPdfCommand request, CancellationToken cancellationToken)
        {
            var relatorio = await _relatorioAcompanhamentoRepository.GetById(request.Id);

            if (relatorio == null)
            {
                throw new Exception("relatório não encontrado.");
            }

            return await _pdfGenerator.GenerateRelatorioPDFAsync(relatorio);
        }
    }
}
