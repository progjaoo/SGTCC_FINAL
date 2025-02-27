using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetById
{
    public class GetProjetoArquivoByIdQuery : IRequest<ProjetoAtividadeDetalheViewModel>
    {
        public int Id { get; set; }

        public GetProjetoArquivoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
