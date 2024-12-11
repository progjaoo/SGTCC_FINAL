using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetById
{
    public class GetAtividadeComentarioByIdQueryHandler : IRequestHandler<GetAtividadeComentarioByIdQuery, AtividadeComentarioViewModel>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;
        public GetAtividadeComentarioByIdQueryHandler(IAtividadeComentarioRepository atividadeComentarioRepository)
        {
            _atividadeComentarioRepository = atividadeComentarioRepository;
        }
        public async Task<AtividadeComentarioViewModel> Handle(GetAtividadeComentarioByIdQuery request, CancellationToken cancellationToken)
        {
            var atividadeComentario = await _atividadeComentarioRepository
                .GetQueryable()
                .Where(ac => ac.Id == request.Id)
                .Select(ac => new AtividadeComentarioViewModel(
                    ac.IdUsuario,
                    ac.IdAtividade,
                    ac.Comentario
                ))
                .FirstOrDefaultAsync(cancellationToken);

            if (atividadeComentario == null)
                throw new Exception("Comentário em atividade não encontrado!");

            return atividadeComentario;
        }
    }
}