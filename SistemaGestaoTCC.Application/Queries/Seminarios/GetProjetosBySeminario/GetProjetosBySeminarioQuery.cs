using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetProjetosBySeminario
{
    public class GetProjetosBySeminarioQuery : IRequest<List<SeminarioProjetosViewModel>>
    {
        public int IdSeminario { get; set; }

        public GetProjetosBySeminarioQuery(int idSeminario)
        {
            IdSeminario = idSeminario;
        }
    }
}
