using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Create
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
            var atividade = new ProjetoAtividade(request.IdProjeto, request.Nome, request.Descricao);

            await _projetoAtividadeRepository.AddASync(atividade);
            await _projetoAtividadeRepository.SaveChangesAsync();

            return atividade.Id;
        }
    }
}
