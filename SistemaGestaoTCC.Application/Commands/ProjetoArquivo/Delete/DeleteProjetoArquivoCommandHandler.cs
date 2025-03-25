using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.Helpers;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using SistemaGestaoTCC.Infrastructure.Repositories;

namespace SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Delete
{
    public class DeleteProjetoArquivoCommandHandler : IRequestHandler<DeleteProjetoArquivoCommand, Unit>
    {
        private readonly IProjetoArquivoRepository _projetoArquivoRepository;
        private readonly IArquivoRepository _arquivoRepository;

        public DeleteProjetoArquivoCommandHandler(IProjetoArquivoRepository projetoArquivoRepository, IArquivoRepository arquivoRepository)
        {
            _projetoArquivoRepository = projetoArquivoRepository;
            _arquivoRepository = arquivoRepository;
        }

        public async Task<Unit> Handle(DeleteProjetoArquivoCommand request, CancellationToken cancellationToken)
        {
            var projetoArquivo = await _projetoArquivoRepository.GetById(request.Id);
            var arquivo = await _arquivoRepository.GetByIdAsync(projetoArquivo.IdArquivo);

            ArquivoHelper.DeletarArquivo(arquivo);

            await _projetoArquivoRepository.Delete(projetoArquivo.Id);

            await _arquivoRepository.DeleteAsync(arquivo.Id);

            return Unit.Value;
        }
    }
}
