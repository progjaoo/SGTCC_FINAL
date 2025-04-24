using MediatR;
using SistemaGestaoTCC.Core.Exceptions;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Create
{
    public class CreateProjetoAtividadeCommandHandler : IRequestHandler<CreateProjetoAtividadeCommand, int>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public CreateProjetoAtividadeCommandHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<int> Handle(CreateProjetoAtividadeCommand request, CancellationToken cancellationToken)
        {
            if (request.DataEntrega.HasValue && request.DataEntrega < DateTime.Now)
            {
                throw new DataEntregaInvalidaException();
            }

            var atividade = new ProjetoAtividade(request.IdProjeto, request.Nome, request.Descricao, request.IdUsuario, request.DuracaoEstimada, request.Prioridade, request.DataInicio,request.DataEntrega);

            await _projetoAtividadeRepository.AddASync(atividade);
            await _projetoAtividadeRepository.SaveChangesAsync();

            return atividade.Id;
        }
    }
}
