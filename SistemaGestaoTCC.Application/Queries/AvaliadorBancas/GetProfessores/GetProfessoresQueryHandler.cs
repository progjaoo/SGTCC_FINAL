using AutoMapper;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Infrastructure.Repositories;

namespace SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetProfessores
{
    public class GetProfessoresQueryHandler : IRequestHandler<GetProfessoresQuery, List<UserRoleViewModel>>
    {
        private readonly IUserRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public GetProfessoresQueryHandler(IUserRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<List<UserRoleViewModel>> Handle(GetProfessoresQuery request, CancellationToken cancellationToken)
        {
            var professores = await _usuarioRepository.GetProfessoresAsync();
            var professoresViewModel = new List<UserRoleViewModel>();

            foreach (var professor in professores)
            {
                await _usuarioRepository.LoadCursoAsync(professor);

                professoresViewModel.Add(new UserRoleViewModel(
                    professor.Id,
                    professor.Nome,
                    professor.Email,
                    professor.Papel,
                    professor.IdCurso ?? 0,
                    professor.IdCursoNavigation?.Nome
                ));
            }

            return professoresViewModel;
        }
    }
}
