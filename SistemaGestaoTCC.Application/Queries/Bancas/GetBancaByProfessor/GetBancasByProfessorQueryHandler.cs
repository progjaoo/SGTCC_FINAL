using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Bancas.GetBancaByProfessor
{
    public class GetBancasByProfessorQueryHandler : IRequestHandler<GetBancasByProfessorQuery, List<BancaDetailViewModel>>
    {
        private readonly IAvaliadorBancaRepository _avaliadorBancaRepository;

        public GetBancasByProfessorQueryHandler(IAvaliadorBancaRepository avaliadorBancaRepository)
        {
            _avaliadorBancaRepository = avaliadorBancaRepository;
        }

        public async Task<List<BancaDetailViewModel>> Handle(GetBancasByProfessorQuery request, CancellationToken cancellationToken)
        {
            var avaliadorBancas = await _avaliadorBancaRepository.GetAllAsync();

            var bancas = avaliadorBancas
                .Where(ab => ab.IdUsuario == request.IdUsuario)
                .Select(ab => ab.IdBancaNavigation)
                .Distinct()
                .ToList();

            var result = bancas.Select(b => new BancaDetailViewModel(
                b.Id,
                b.IdProjeto,
                b.DataSeminario,
                b.Parecer,
                b.ObservacaoNotaProjeto,
                b.ObservacaoAluno,
                b.Recomendacao
            )).ToList();

            return result;
        }
    }
}
