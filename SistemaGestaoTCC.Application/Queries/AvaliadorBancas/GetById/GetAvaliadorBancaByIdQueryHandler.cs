using AutoMapper;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliadorBancaVM;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetById
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
