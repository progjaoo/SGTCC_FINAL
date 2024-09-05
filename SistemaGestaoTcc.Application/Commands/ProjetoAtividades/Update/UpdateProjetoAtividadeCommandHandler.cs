using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Update
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

            atividade.UpdateAtividade(request.IdProjeto, request.Nome, request.Descricao);

            await _projetoAtividadeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
