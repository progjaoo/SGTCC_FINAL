using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Bancas.GetById
{
    public class GetBancaByIdQueryHandler : IRequestHandler<GetBancaByIdQuery, BancaDetailViewModel>
    {
        private readonly IBancaRepository _bancaRepository;
        public GetBancaByIdQueryHandler(IBancaRepository bancaRepository)
        {
            _bancaRepository = bancaRepository;
        }
        public async Task<BancaDetailViewModel> Handle(GetBancaByIdQuery request, CancellationToken cancellationToken)
        {
            var banca = await _bancaRepository.GetById(request.Id);

            var bancaDetailViewModel = new BancaDetailViewModel(
                banca.Id,
                banca.IdProjeto,
                banca.DataSeminario,
                banca.Parecer,
                banca.ObservacaoNotaProjeto,
                banca.ObservacaoAluno,
                banca.Recomendacao);

            return bancaDetailViewModel;
        }
    }
}
