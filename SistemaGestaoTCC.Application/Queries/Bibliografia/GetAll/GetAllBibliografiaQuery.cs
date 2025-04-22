using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BibliografiaVM;

namespace SistemaGestaoTCC.Application.Queries.Bibliografia.GetAll
{
    public class GetAllBibliografiaQuery : IRequest<List<BibliografiaViewModel>> { }
}
