using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BibliografiaVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Bibliografia.GetById
{
    public class GetBibliografiaByIdQueryHandler : IRequestHandler<GetBibliografiaByIdQuery, BibliografiaDetalheViewModel>
    {
        private readonly IBibliografiaRepository _bibliografiaRepository;
        public GetBibliografiaByIdQueryHandler(IBibliografiaRepository bibliografiaRepository)
        {
            _bibliografiaRepository = bibliografiaRepository;
        }
        public async Task<BibliografiaDetalheViewModel> Handle(GetBibliografiaByIdQuery request, CancellationToken cancellationToken)
        {
            var bibliografia = await _bibliografiaRepository.GetById(request.Id);

            if (bibliografia == null)
            {
                return null;
            }

            var bibliografiaDetalheViewModel = new BibliografiaDetalheViewModel
                (
                bibliografia.IdUsuario,
                bibliografia.IdProjeto,
                bibliografia.Autores,
                bibliografia.Referencia,
                bibliografia.AcessadoEm,
                bibliografia.CriadoEm,
                bibliografia.EditadoEm);

            return bibliografiaDetalheViewModel;
        }
    }
}
