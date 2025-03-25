using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoArquivo.GetAllAsync
{
    public class GetAllProjetoArquivoQuery : IRequest<List<ArquivoViewModel>> 
    {
        public int IdProjeto { get; set; }
    }
}