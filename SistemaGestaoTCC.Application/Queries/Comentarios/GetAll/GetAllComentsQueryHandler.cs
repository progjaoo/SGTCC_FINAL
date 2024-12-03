using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ComentariosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetAll
{
    public class GetAllComentsQueryHandler : IRequestHandler<GetAllComentsQuery, List<ComentarioViewModel>>
    {
        private readonly IProjetoComentarioRepository _projetoComentarioRepository;
        public GetAllComentsQueryHandler(IProjetoComentarioRepository projetoComentarioRepository)
        {
            _projetoComentarioRepository = projetoComentarioRepository;
        }
        public async Task<List<ComentarioViewModel>> Handle(GetAllComentsQuery request, CancellationToken cancellationToken)
        {
            var coment = await _projetoComentarioRepository.GetAllAsync();

            var comentViewModel = coment.Select(c => new ComentarioViewModel(
                c.IdProjeto,
                c.Comentario)).ToList();

            return comentViewModel;
        }
    }
}
