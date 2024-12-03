using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Users.FindUsers
{
    public class FindUsersQueryHandler : IRequestHandler<FindUsersQuery, List<UserRoleViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public FindUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserRoleViewModel>> Handle(FindUsersQuery request, CancellationToken cancellationToken)
        {
            var listUserRole = await _userRepository.FilterUsers(request.Papel, request.Nome);

            var listUserViewModel = listUserRole
                .Select(p => new UserRoleViewModel(p.Nome, p.Email, p.Papel, p.IdCurso)).ToList();

            return listUserViewModel;
        }
    }
}
