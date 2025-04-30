using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Relatorios.Update
{
    public class UpdateRelatorioCommandHandler : IRequestHandler<UpdateRelatorioCommand, Unit>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioRepository;

        public UpdateRelatorioCommandHandler(IRelatorioAcompanhamentoRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<Unit> Handle(UpdateRelatorioCommand request, CancellationToken cancellationToken)
        {
            var relatorio = await _relatorioRepository.GetById(request.Id);

            if (relatorio == null)
            {
                throw new Exception("Relatório não encontrado.");
            }
            relatorio.UpdateRelatorio(
                request.IdProfessor,
                request.IdProjeto,
                request.Titulo,
                request.Descricao,
                request.DuracaoEncontro,
                request.DataRealizacao
            );
            await _relatorioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
