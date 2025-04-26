using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BibliografiaVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Bibliografia.GetBibliografiaByProject
{
    public class GetBibliografiaByProjectQueryHandler : IRequestHandler<GetBibliografiaByProjectQuery, List<BibliografiaViewModel>>
    {
        private readonly IBibliografiaRepository _bibliografiaRepository;
        public GetBibliografiaByProjectQueryHandler(IBibliografiaRepository bibliografiaRepository)
        {
            _bibliografiaRepository = bibliografiaRepository;
        }
        public async Task<List<BibliografiaViewModel>> Handle(GetBibliografiaByProjectQuery request, CancellationToken cancellationToken)
        {
            var bibliografias = await _bibliografiaRepository.GetBibliografiasByProject(request.IdProjeto);

            if (bibliografias == null)
                throw new Exception("Bibliografia não encontrado!");

            return bibliografias.Select(a => new BibliografiaViewModel(a.Id, a.IdUsuario, a.IdProjeto, a.Autores, a.Referencia, a.AcessadoEm)).ToList();
        }
    }
}
