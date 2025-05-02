using MediatR;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto.ResponderConviteProjeto
{
    public class ResponderConviteProjetoCommandHandler : IRequestHandler<ResponderConviteProjetoCommand, Unit>
    {
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        public ResponderConviteProjetoCommandHandler(IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<Unit> Handle(ResponderConviteProjetoCommand request, CancellationToken cancellationToken)
        {
            var userProject = await _usuarioProjetoRepository.GetById(request.IdConvite);

            if (userProject == null)
            {
                throw new Exception($"Convite não encontrado");
            }

            var respostaInvalida = request.Resposta != ConviteEnum.Rejeitado || request.Resposta != ConviteEnum.Aceito;
            if (respostaInvalida)
            {
                throw new Exception($"Valor de requisição inválido!");
            }

            if (userProject.EstaExpirado())
            {
                userProject.Estado = ConviteEnum.Expirado;
                await _usuarioProjetoRepository.SaveChangesAsync();
                throw new Exception($"Convite expirado!");
            }

            if (userProject.EstaRespondido())
            {
                throw new Exception($"Convite já foi respondido!");
            }

            userProject.Estado = request.Resposta;

            await _usuarioProjetoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}