using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto.ResponderConviteProjeto
{
    public class ResponderConviteProjetoCommand : IRequest<Unit>
    {
        public int IdConvite { get; set; }
        public ConviteEnum Resposta { get; set; }
        public ResponderConviteProjetoCommand(int IdConvite, ConviteEnum Resposta)
        {
            this.IdConvite = IdConvite;
            this.Resposta = Resposta;
        }
    }
}