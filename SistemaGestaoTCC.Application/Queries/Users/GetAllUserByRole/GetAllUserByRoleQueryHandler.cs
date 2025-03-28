using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllUserByRole
{
    public class GetAllUserByRoleQueryHandler : IRequestHandler<GetAllUserByRoleQuery, List<UserRoleViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserByRoleQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserRoleViewModel>> Handle(GetAllUserByRoleQuery request, CancellationToken cancellationToken)
        {
            var listUserRole = await _userRepository.GetAllUserByRole(request.Papel);

            var listUserViewModel = listUserRole
                .Select(p => new UserRoleViewModel(p.Id, p.Nome, p.Email, p.Papel, p.IdCurso, p.IdCursoNavigation.Nome)).ToList();

            return listUserViewModel;
        }
    }
}
