using AutoMapper.Execution;
using MediatR;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new Exception("relat[orio não encontrado.");
            }

            return await _pdfGenerator.GenerateRelatorioPDFAsync(relatorio);
        }
    }
}
