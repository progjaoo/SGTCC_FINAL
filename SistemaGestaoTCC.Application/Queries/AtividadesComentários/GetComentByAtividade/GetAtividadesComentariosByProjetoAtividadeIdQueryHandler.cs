using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetComentByAtividade
{
    public class GetAtividadesComentariosByProjetoAtividadeIdQueryHandler : IRequestHandler<GetAtividadesComentariosByProjetoAtividadeIdQuery, List<AtividadeComentarioViewModel>>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;

        public GetAtividadesComentariosByProjetoAtividadeIdQueryHandler(IAtividadeComentarioRepository repository)
        {
            _atividadeComentarioRepository = repository;
        }

        public async Task<List<AtividadeComentarioViewModel>> Handle(GetAtividadesComentariosByProjetoAtividadeIdQuery request, CancellationToken cancellationToken)
        {
           var comentarios = await _atividadeComentarioRepository.GetAllComentarioByAtividadeIdAsync(request.IdProjetoAtividade);

            var comentariosViewModel = comentarios
                .Select(p => new AtividadeComentarioViewModel(p.IdUsuario, p.IdAtividade,p.Comentario))
                .ToList();

            return comentariosViewModel;
        }
    }
}
