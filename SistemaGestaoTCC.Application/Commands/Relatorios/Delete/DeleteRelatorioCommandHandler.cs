using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Relatorios.Delete
{
    public class DeleteRelatorioCommandHandler : IRequestHandler<DeleteRelatorioCommand, Unit>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioRepository;
        public DeleteRelatorioCommandHandler(IRelatorioAcompanhamentoRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }
        public async Task<Unit> Handle(DeleteRelatorioCommand request, CancellationToken cancellationToken)
        {
            var relatorio = await _relatorioRepository.GetById(request.Id);

            if (relatorio == null)
            {
                throw new Exception("Relatório não encontrado.");
            }

            await _relatorioRepository.DeleteAsync(relatorio.Id);
            await _relatorioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}