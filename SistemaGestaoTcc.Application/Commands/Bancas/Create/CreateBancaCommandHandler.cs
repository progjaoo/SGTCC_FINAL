using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Bancas.Create
{
    public class CreateBancaCommandHandler : IRequestHandler<CreateBancaCommand, int>
    {
        private readonly IBancaRepository _bancaRepository;
        public CreateBancaCommandHandler(IBancaRepository bancaRepository)
        {
            _bancaRepository = bancaRepository;
        }
        public async Task<int> Handle(CreateBancaCommand request, CancellationToken cancellationToken)
        {
            var banca = new Banca(
                request.IdProjeto, 
                request.DataSeminario, 
                request.Parecer, 
                request.ObservacaoNotaProjeto,
                request.ObservacaoAluno, 
                request.Recomendacao);

            await _bancaRepository.AddASync(banca);
            await _bancaRepository.SaveChangesAsync();

            return banca.Id;
        }
    }
}
