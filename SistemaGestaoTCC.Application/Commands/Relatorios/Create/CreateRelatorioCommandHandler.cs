using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Relatorios.Create
{
    public class CreateRelatorioCommandHandler : IRequestHandler<CreateRelatorioCommand, int>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioRepository;
        public CreateRelatorioCommandHandler(IRelatorioAcompanhamentoRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<int> Handle(CreateRelatorioCommand request, CancellationToken cancellationToken)
        {
            var relatorio = new RelatorioAcompanhamento(
                request.IdProfessor,
                request.IdProjeto,
                request.Titulo,
                request.Descricao,
                request.DuracaoEncontro,
                request.DataRealizacao
            );
            if (relatorio != null)
            {
                throw new Exception("Relatório já existe para este projeto.");
            }

            await _relatorioRepository.AddAsync(relatorio);
            await _relatorioRepository.SaveChangesAsync();

            return relatorio.Id;
        }
    }
}