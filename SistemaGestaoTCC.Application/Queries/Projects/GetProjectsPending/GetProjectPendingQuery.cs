using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsPending
{
    public class GetProjectPendingQuery : IRequest<List<ProjectViewModel>>
    {
        //public GetProjectQuery(string query)
        //{
        //    Query = query;
        //}

        public string Query { get; set; }
    }
}
