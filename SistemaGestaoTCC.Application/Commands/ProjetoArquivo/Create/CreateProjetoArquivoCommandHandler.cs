using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SistemaGestaoTCC.Application.Helpers;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using SistemaGestaoTCC.Infrastructure.Services;

namespace SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Create
{
    public class CreateProjetoArquivoCommandHandler : IRequestHandler<CreateProjetoArquivoCommand, int>
    {
        private readonly IProjectRepository _projetoRepository;
        private readonly IProjetoArquivoRepository _projetoArquivoRepository;
        private readonly IArquivoRepository _arquivoRepository;

        public CreateProjetoArquivoCommandHandler(
            IProjetoArquivoRepository projetoArquivoRepository,
            IProjectRepository projetoRepository,
            IArquivoRepository arquivoRepository
        )
        {
            _projetoArquivoRepository = projetoArquivoRepository;
            _projetoRepository = projetoRepository;
            _arquivoRepository = arquivoRepository;
        }

        public async Task<int> Handle(CreateProjetoArquivoCommand request, CancellationToken cancellationToken)
        {
            var projeto = await _projetoRepository.GetById(request.IdProjeto);

            if (projeto == null) {
                throw new Exception("Projeto não Existe!");
            }

            var extensaoArquivo = Path.GetExtension(request.File.FileName);

            var arquivo = new Arquivo(
                request.File.FileName,
                request.FolderName,
                (int)request.File.Length,
                extensaoArquivo
            );

            var novoArquivo = await _arquivoRepository.AddAsync(arquivo);

            var projetoArquivo = new Core.Models.ProjetoArquivo(
                projeto.Id,
                request.IdUsuario,
                novoArquivo.Id,
                1
            );

            await _projetoArquivoRepository.AddASync(projetoArquivo);

            await ArquivoHelper.SalvarArquivo(request.File, request.FolderName, novoArquivo.Id);

            return novoArquivo.Id;
        }
    }
}
