using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetFinishProjectsByName
{
    public class GetAllFInishProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public string Query { get; set; }

        public GetAllFInishProjectsQuery(string query)
        {
            Query = query;
        }
    }
}
