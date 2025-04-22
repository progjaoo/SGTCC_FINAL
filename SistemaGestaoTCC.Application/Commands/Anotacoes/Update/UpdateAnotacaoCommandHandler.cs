using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Update
{
    public class UpdateAnotacaoCommandHandler : IRequestHandler<UpdateAnotacaoCommand, Unit>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;
        public UpdateAnotacaoCommandHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }
        public async Task<Unit> Handle(UpdateAnotacaoCommand request, CancellationToken cancellationToken)
        {
            var anotacao = await _anotacaoRepository.GetById(request.Id);
            if (anotacao == null)
            {
                throw new Exception("Anotação não encontrada");
            }
            anotacao.UpdateAnotacao(anotacao.IdUsuario, anotacao.IdProjeto, anotacao.Titulo, anotacao.Descricao);
            await _anotacaoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
