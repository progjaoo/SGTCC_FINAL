using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Update
{
    public class UpdateProjetoAtividadeCommandHandler : IRequestHandler<UpdateProjetoAtividadeCommand, Unit>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public UpdateProjetoAtividadeCommandHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<Unit> Handle(UpdateProjetoAtividadeCommand request, CancellationToken cancellationToken)
        {
            var atividade = await _projetoAtividadeRepository.GetById(request.Id);

            atividade.UpdateAtividade(request.IdProjeto, request.Nome, request.Descricao, request.IdUsuario, 
                request.DuracaoEstimada, request.Prioridade, request.DataInicio, request.DataEntrega);

            await _projetoAtividadeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
