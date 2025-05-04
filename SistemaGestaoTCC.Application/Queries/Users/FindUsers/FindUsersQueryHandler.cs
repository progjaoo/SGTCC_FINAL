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
            var listUserRolesViewModel = new List<UserRoleViewModel>();

            foreach (var lists in listUserRole)
            {
                await _userRepository.LoadCursoAsync(lists);

                listUserRolesViewModel.Add(new UserRoleViewModel(
                    lists.Id,
                    lists.Nome,
                    lists.Email,
                    lists.Papel,
                    lists.IdCurso ?? 0,
                    lists.IdCursoNavigation?.Nome
                ));
            }

            return listUserRolesViewModel;
        }
    }
}
