using MediatR;
using SistemaGestaoTCC.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.UpdateStatus
{
    public class AtualizarStatusAtividadeCommand : IRequest<bool>
    {
        public int IdAtividade { get; }
        public ProjetoAtividadeEnum NovoEstado { get; }

        public AtualizarStatusAtividadeCommand(int idAtividade, ProjetoAtividadeEnum novoEstado)
        {
            IdAtividade = idAtividade;
            NovoEstado = novoEstado;
        }
    }
}
