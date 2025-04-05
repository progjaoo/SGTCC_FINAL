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
    public class GetAllUserByRoleQueryHandler : IRequestHandler<GetAllUserByRoleQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserByRoleQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUserByRoleQuery request, CancellationToken cancellationToken)
        {
            var listUserRole = await _userRepository.GetAllUserByRole(request.Papel);

            var listUserViewModel = listUserRole
                .Select(u => new UserViewModel(u.Id, u.Nome, u.Email, u.IdCurso, u.IdCursoNavigation.Nome, u.Papel, u.IdImagemNavigation)).ToList();

            return listUserViewModel;
        }
    }
}
