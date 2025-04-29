using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetByTitulo
{
    public class GetAnotacoesByTituloQuery : IRequest<List<AnotacaoViewModel>>
    {
        public string Titulo { get; set; }
        public int IdProjeto { get; set; }

        public GetAnotacoesByTituloQuery(string titulo, int idProjeto)
        {
            Titulo = titulo;
            IdProjeto = idProjeto;
        }
    }
}
