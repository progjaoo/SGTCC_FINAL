using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Create
{
    public class CreateAnotacaoCommandHandler : IRequestHandler<CreateAnotacaoCommand, int>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;
        public CreateAnotacaoCommandHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }
        public async Task<int> Handle(CreateAnotacaoCommand request, CancellationToken cancellationToken)
        {
            var anotacao = new Anotacao(request.IdUsuario, request.IdProjeto, request.Titulo, request.Descricao);

            await _anotacaoRepository.AddAsync(anotacao);
            await _anotacaoRepository.SaveChangesAsync();

            return anotacao.Id;
        }
    }
}
