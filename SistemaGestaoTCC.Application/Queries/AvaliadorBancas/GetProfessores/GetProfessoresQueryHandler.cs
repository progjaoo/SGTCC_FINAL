using AutoMapper;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

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
            return _mapper.Map<List<UserRoleViewModel>>(professores);
        }
    }
}
