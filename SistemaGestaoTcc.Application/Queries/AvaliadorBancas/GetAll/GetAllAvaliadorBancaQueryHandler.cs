using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AvaliadorBancaVM;
using SistemaGestaoTcc.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.Queries.AvaliadorBancas.GetAll
{
    public class GetAllAvaliadorBancaQueryHandler : IRequestHandler<GetAllAvaliadorBancaQuery, List<AvaliadorBancaViewModel>>
    {
        private readonly IAvaliadorBancaRepository _avaliadorBancaRepository;

        public GetAllAvaliadorBancaQueryHandler(IAvaliadorBancaRepository avaliadorBancaRepository)
        {
            _avaliadorBancaRepository = avaliadorBancaRepository;
        }

        public async Task<List<AvaliadorBancaViewModel>> Handle(GetAllAvaliadorBancaQuery request, CancellationToken cancellationToken)
        {
            var avaliadores = await _avaliadorBancaRepository.GetAllAsync();

            var viewModel = avaliadores.Select(avaliador => new AvaliadorBancaViewModel
            {
                Id = avaliador.Id,
                IdUsuario = avaliador.IdUsuario,
                NomeUsuario = avaliador.IdUsuarioNavigation.Nome,
                EmailUsuario = avaliador.IdUsuarioNavigation.Email,
                IdBanca = avaliador.IdBanca
            }).ToList();

            return viewModel;
        }
    }
}
