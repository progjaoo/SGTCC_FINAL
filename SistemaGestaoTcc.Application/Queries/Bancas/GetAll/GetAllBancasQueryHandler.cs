using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Bancas.GetAll
{
    public class GetAllBancasQueryHandler : IRequestHandler<GetAllBancasQuery, List<BancaViewModel>>
    {
        private readonly IBancaRepository _bancaRepository;
        public GetAllBancasQueryHandler(IBancaRepository bancaRepository)
        {
            _bancaRepository = bancaRepository;
        }
        public async Task<List<BancaViewModel>> Handle(GetAllBancasQuery request, CancellationToken cancellationToken)
        {
            var banca = await _bancaRepository.GetAllAsync();

            var bancaViewModel = banca.Select(b => new BancaViewModel(
                b.Id,
                b.IdProjeto,
                b.DataSeminario,
                b.Parecer)).ToList();

            return bancaViewModel;
        }
    }
}
