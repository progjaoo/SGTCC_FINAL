using MediatR;
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
            var atividade = new ProjetoAtividade(request.IdProjeto, request.Nome, request.Descricao, request.IdUsuario, request.DuracaoEstimada, request.Prioridade, request.DataInicio,request.DataEntrega);

            await _projetoAtividadeRepository.AddASync(atividade);
            await _projetoAtividadeRepository.SaveChangesAsync();

            return atividade.Id;
        }
    }
}
