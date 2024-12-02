using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Create
{
    public class CreateProjetoEntregaCommandHandler : IRequestHandler<CreateProjetoEntregaCommand, int>
    {
        private readonly IProjetoEntregaRepository _projetoEntregaRepository;
        public CreateProjetoEntregaCommandHandler(IProjetoEntregaRepository projetoEntregaRepository)
        {
            _projetoEntregaRepository = projetoEntregaRepository;
        }
        public async Task<int> Handle(CreateProjetoEntregaCommand request, CancellationToken cancellationToken)
        {
            var entrega = new ProjetoEntrega(request.IdProjeto, request.Titulo, request.DataLimite, request.DataEnvio, request.Entregue);

            await _projetoEntregaRepository.AddAsync(entrega);
            await _projetoEntregaRepository.SaveChangesAsync();

            return entrega.Id;
        }
    }
}