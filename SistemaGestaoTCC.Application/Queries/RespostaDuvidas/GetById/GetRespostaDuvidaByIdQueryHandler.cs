using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetById
{
    public class GetRespostaDuvidaByIdQueryHandler : IRequestHandler<GetRespostaDuvidaByIdQuery, RespostaDuvidaViewModel>
    {
        private readonly IRespostaDuvidaRepository _respostaRepository;

        public GetRespostaDuvidaByIdQueryHandler(IRespostaDuvidaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public async Task<RespostaDuvidaViewModel> Handle(GetRespostaDuvidaByIdQuery request, CancellationToken cancellationToken)
        {
            var resposta = await _respostaRepository.GetByIdAsync(request.Id);
            if (resposta == null)
                throw new Exception("Resposta não encontrada");

            return new RespostaDuvidaViewModel(
                resposta.Id, resposta.IdDuvida, resposta.IdUsuario, resposta.Texto,
                resposta.IdUsuarioNavigation?.Nome, resposta.CriadoEm);
        }
    }
}
