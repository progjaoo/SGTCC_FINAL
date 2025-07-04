﻿using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetAll
{
    public class GetAllAnotacoesQueryHandler : IRequestHandler<GetAllAnotacoesQuery, List<AnotacaoViewModel>>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;
        public GetAllAnotacoesQueryHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }
        public async Task<List<AnotacaoViewModel>> Handle(GetAllAnotacoesQuery request, CancellationToken cancellationToken)
        {
            var anotacoes = await _anotacaoRepository.GetAllAsync();
            return anotacoes.Select(a => new AnotacaoViewModel(a.IdUsuario, a.IdProjeto, a.Titulo, a.Descricao, a.CriadoEm)).ToList();
        }
    }
}
