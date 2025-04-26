using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BibliografiaVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Bibliografia.GetAll
{
    public class GetAllBibliografiaQueryHandler : IRequestHandler<GetAllBibliografiaQuery, List<BibliografiaViewModel>>
    {
        private readonly IBibliografiaRepository _bibliografiaRepository;
        public GetAllBibliografiaQueryHandler(IBibliografiaRepository bibliografiaRepository)
        {
            _bibliografiaRepository = bibliografiaRepository;
        }
        public async Task<List<BibliografiaViewModel>> Handle(GetAllBibliografiaQuery request, CancellationToken cancellationToken)
        {
            var bibliografias = await _bibliografiaRepository.GetAllAsync();
            return bibliografias.Select(a => new BibliografiaViewModel(a.Id,a.IdUsuario, a.IdProjeto, a.Autores, a.Referencia, a.AcessadoEm)).ToList();
        }
    }
}