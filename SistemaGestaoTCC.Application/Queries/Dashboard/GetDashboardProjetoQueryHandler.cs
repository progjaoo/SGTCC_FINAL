using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Application.ViewModels.DashaboarVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Dashboard
{
    public class GetDashboardProjetoQueryHandler : IRequestHandler<GetDashboardProjetoQuery, DashboardProjetoViewModel>
    {
        private readonly SGTCCContext _context;

        public GetDashboardProjetoQueryHandler(SGTCCContext context)
        {
            _context = context;
        }

        public async Task<DashboardProjetoViewModel> Handle(GetDashboardProjetoQuery request, CancellationToken cancellationToken)
        {
            var projeto = await _context.Projeto
                .Include(p => p.ProjetoAtividades)
                    .ThenInclude(a => a.AtividadeComentarios)
                .Include(p => p.ProjetoComentarios)
                .Include(p => p.UsuarioProjetos)
                    .ThenInclude(up => up.IdUsuarioNavigation)
                .FirstOrDefaultAsync(p => p.Id == request.ProjetoId, cancellationToken);

            if (projeto == null) return null;

            var totalAtividades = projeto.ProjetoAtividades.Count;
            var concluidas = projeto.ProjetoAtividades.Count(a => a.Estado == ProjetoAtividadeEnum.Finalizada);
            var atrasadas = projeto.ProjetoAtividades.Count(a => a.Estado != ProjetoAtividadeEnum.Finalizada && a.DataEntrega < DateTime.Now);

            var atividadesVm = projeto.ProjetoAtividades.Select(a => new DashboardAtividadeViewModel
            {
                Nome = a.Nome,
                Usuario = a.IdUsuarioNavigation?.Nome ?? "Desconhecido",
                Prioridade = a.Prioridade.ToString(),
                Estado = a.Estado.ToString(),
                DataEntrega = a.DataEntrega,
                Atrasada = a.DataEntrega.HasValue && a.DataEntrega.Value < DateTime.Now && a.Estado != ProjetoAtividadeEnum.Finalizada,
                Comentarios = a.AtividadeComentarios.Select(c => c.Comentario).ToList()
            }).ToList();

            var comentariosProjeto = projeto.ProjetoComentarios.Select(c => new DashboardAtividadeViewModel
            {
                Nome = "Comentário Projeto",
                Usuario = c.IdUsuarioNavigation?.Nome ?? "Desconhecido",
                Prioridade = "-",
                Estado = "-",
                DataEntrega = null,
                Atrasada = false,
                Comentarios = new List<string> { c.Comentario }
            }).ToList();

            return new DashboardProjetoViewModel
            {
                NomeProjeto = projeto.Nome,
                Descricao = projeto.Descricao,
                DataInicio = projeto.DataInicio,
                DataFim = projeto.DataFim,
                Estado = projeto.Estado.ToString(),
                TotalAtividades = totalAtividades,
                AtividadesConcluidas = concluidas,
                AtividadesAtrasadas = atrasadas,
                Atividades = atividadesVm,
                ComentariosProjeto = comentariosProjeto
            };
        }
    }

}
