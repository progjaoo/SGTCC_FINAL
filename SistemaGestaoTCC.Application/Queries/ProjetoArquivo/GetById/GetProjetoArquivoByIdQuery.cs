using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoArquivo.GetById
{
    public class GetProjetoArquivoByIdQuery : IRequest<ArquivoViewModel>
    {
        public int Id { get; set; }

        public GetProjetoArquivoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
