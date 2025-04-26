using MediatR;
using Microsoft.AspNet.SignalR;
using SistemaGestaoTCC.Application.ViewModels.BibliografiaVM;

namespace SistemaGestaoTCC.Application.Queries.Bibliografia.GetBibliografiaByProject
{
    public class GetBibliografiaByProjectQuery : IRequest<List<BibliografiaViewModel>>
    {
        public GetBibliografiaByProjectQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
        public int IdProjeto { get; set; }
    }
}
