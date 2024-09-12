using AutoMapper;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AvaliadorBancaVM;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.AvaliadorBancas.GetByBanca
{
    public class GetAvaliadorBancaByBancaIdQueryHandler : IRequestHandler<GetAvaliadorBancaByBancaIdQuery, List<AvaliadorBancaViewModel>>
    {
        private readonly IAvaliadorBancaRepository _avaliadorBancaRepository;

        public GetAvaliadorBancaByBancaIdQueryHandler(IAvaliadorBancaRepository avaliadorBancaRepository)
        {
            _avaliadorBancaRepository = avaliadorBancaRepository;
        }

        public async Task<List<AvaliadorBancaViewModel>> Handle(GetAvaliadorBancaByBancaIdQuery request, CancellationToken cancellationToken)
        {
            var avaliadores = await _avaliadorBancaRepository.GetByBancaIdAsync(request.IdBanca);

            var viewModel = avaliadores.Select(avaliador => new AvaliadorBancaViewModel
            {
                Id = avaliador.Id,
                IdUsuario = avaliador.IdUsuario,
                NomeUsuario = avaliador.IdUsuarioNavigation.Nome,
                EmailUsuario = avaliador.IdUsuarioNavigation.Email,
                IdBanca = avaliador.IdBanca
            }).ToList();

            return viewModel;
        }
    }
}
