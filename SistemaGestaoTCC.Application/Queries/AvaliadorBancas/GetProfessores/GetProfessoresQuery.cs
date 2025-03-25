using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetProfessores
{
    public class GetProfessoresQuery : IRequest<List<UserRoleViewModel>>
    {
        public int Id { get; set; }
    }
}
