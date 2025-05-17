using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidaByUser
{

    public class GetDuvidaByUserQueryHandler : IRequestHandler<GetDuvidaByUserQuery, List<DuvidasViewModel>>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public GetDuvidaByUserQueryHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async  Task<List<DuvidasViewModel>> Handle(GetDuvidaByUserQuery request, CancellationToken cancellationToken)
        {
            var duvidas = await _duvidaRepository.GetByUsuarioIdAsync(request.IdUsuario);

            if (duvidas == null || !duvidas.Any())
            {
                throw new Exception("Nenhuma dúvida encontrada para este usuário");
            }
            var duvidasViewModel = duvidas.Select(duvida => new DuvidasViewModel(duvida.Id, duvida.IdProjeto, duvida.IdUsuario, 
                duvida.Texto, duvida.Visibilidade, duvida.Atendida, duvida.CriadoEm, duvida.IdUsuarioNavigation.Nome)).ToList();

            return duvidasViewModel;
        }
    }

}
