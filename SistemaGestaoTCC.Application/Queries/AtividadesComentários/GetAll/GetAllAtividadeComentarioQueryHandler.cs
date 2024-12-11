using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetAll
{
    public class GetAllAtividadeComentarioQueryHandler : IRequestHandler<GetAllAtividadeComentarioQuery, List<AtividadeComentarioViewModel>>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;

        public GetAllAtividadeComentarioQueryHandler(IAtividadeComentarioRepository atividadeComentarioRepository)
        {
            _atividadeComentarioRepository = atividadeComentarioRepository;
        }

        public async Task<List<AtividadeComentarioViewModel>> Handle(GetAllAtividadeComentarioQuery request, CancellationToken cancellationToken)
        {
            var atividadeComentarios = await _atividadeComentarioRepository.GetQueryable()
                .Select(ac => new AtividadeComentarioViewModel(
                    ac.IdUsuario,
                    ac.IdAtividade,
                    ac.Comentario
                ))
                .ToListAsync(cancellationToken);

            return atividadeComentarios;
        }
    }
}
