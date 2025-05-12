using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidasByProjetoAndStatus
{
    public class GetDuvidasByProjetoAndStatusQuery : IRequest<List<DuvidasViewModel>>
    {
        public int IdProjeto { get; set; }
        public int Atendida { get; set; }

        public GetDuvidasByProjetoAndStatusQuery(int idProjeto, int atendida)
        {
            IdProjeto = idProjeto;
            Atendida = atendida;
        }
    }
}
