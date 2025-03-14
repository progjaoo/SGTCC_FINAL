using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM;

namespace SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetComentByAtividade
{
    public class GetAtividadesComentariosByProjetoAtividadeIdQuery : IRequest<List<AtividadeComentarioViewModel>>
    {
        public int IdProjetoAtividade { get; set; }

        public GetAtividadesComentariosByProjetoAtividadeIdQuery(int idProjetoAtividade)
        {
            IdProjetoAtividade = idProjetoAtividade;
        }
    }
}
