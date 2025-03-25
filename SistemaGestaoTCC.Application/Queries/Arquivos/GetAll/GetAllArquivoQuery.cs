using MediatR;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Arquivos.GetAll
{
    public class GetAllArquivoQuery : IRequest<List<Arquivo>> { }
}
