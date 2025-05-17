using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetSeminariosById
{
    public class GetSeminarioByIdQueryHandler : IRequestHandler<GetSeminarioByIdQuery, SeminarioViewModel>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public GetSeminarioByIdQueryHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<SeminarioViewModel> Handle(GetSeminarioByIdQuery request, CancellationToken cancellationToken)
        {
            var seminario = await _seminarioRepository.GetById(request.Id);
            if (seminario == null)
            {
                throw new Exception("Seminário não encontrado");
            }
            return new SeminarioViewModel(seminario.Id, seminario.IdUsuario, seminario.Requisitos, seminario.Data,seminario.CriadoEm,seminario.EditadoEm, seminario.IdUsuarioNavigation?.Nome);
        }
    }
}
