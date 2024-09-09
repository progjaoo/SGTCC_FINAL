using AutoMapper;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AvaliadorBancaVM;
using SistemaGestaoTcc.Application.ViewModels.BacanVM;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.AvaliadorBancas.GetById
{
    public class GetAvaliadorBancaByIdQueryHandler : IRequestHandler<GetAvaliadorBancaByIdQuery, AvaliadorBancaDetalheViewModel>
    {
        private readonly IAvaliadorBancaRepository _avaliadorBancaRepository;

        public GetAvaliadorBancaByIdQueryHandler(IAvaliadorBancaRepository avaliadorBancaRepository)
        {
            _avaliadorBancaRepository = avaliadorBancaRepository;
        }
        public async Task<AvaliadorBancaDetalheViewModel> Handle(GetAvaliadorBancaByIdQuery request, CancellationToken cancellationToken)
        {
            var avaliadorBanca = await _avaliadorBancaRepository.GetByIdAsync(request.Id);

            var bancaDetailViewModel = new AvaliadorBancaDetalheViewModel(
                avaliadorBanca.Id,
                avaliadorBanca.IdUsuario,
                avaliadorBanca.IdBanca
                );

            return bancaDetailViewModel;
        }
    }
}
