﻿using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoArquivo.GetAllAsync
{
    public class GetAllProjetoArquivoQueryHandler : IRequestHandler<GetAllProjetoArquivoQuery, List<ArquivoViewModel>>
    {
        private readonly IProjetoArquivoRepository _projetoArquivoRepository;
        public GetAllProjetoArquivoQueryHandler(IProjetoArquivoRepository projetoArquivoRepository)
        {
            _projetoArquivoRepository = projetoArquivoRepository;
        }
        public async Task<List<ArquivoViewModel>> Handle(GetAllProjetoArquivoQuery request, CancellationToken cancellationToken)
        {
            var projetoArquivos = await _projetoArquivoRepository.GetAllByProjectIdAsync(request.IdProjeto);

            var listProjetoArquivoViewModel = projetoArquivos.Select(
                p => new ArquivoViewModel(
                    p.IdArquivoNavigation.Id,
                    p.IdArquivoNavigation.NomeOriginal,
                    p.IdArquivoNavigation.Diretorio,
                    p.IdArquivoNavigation.Tamanho,
                    p.IdArquivoNavigation.Extensao,
                    p.Id,
                    p.IdArquivoNavigation.CriadoEm,
                    p.IdArquivoNavigation.EditadoEm
                )
                ).ToList();

            // var atividadeViewModel = atividade.Select(a => new ProjetoAtividadeViewModel(a.IdProjeto, a.Nome)).ToList();

            return listProjetoArquivoViewModel;
        }
    }
}
