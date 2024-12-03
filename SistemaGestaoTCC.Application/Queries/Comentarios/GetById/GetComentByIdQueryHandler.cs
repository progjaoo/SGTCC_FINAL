using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ComentariosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetById
{
    public class GetComentByIdQueryHandler : IRequestHandler<GetComentByIdQuery, ComentarioViewModel>
    {
        private readonly IProjetoComentarioRepository _projetoComentarioRepository;
        public GetComentByIdQueryHandler(IProjetoComentarioRepository projetoComentarioRepository)
        {
            _projetoComentarioRepository = projetoComentarioRepository;
        }
        public async Task<ComentarioViewModel> Handle(GetComentByIdQuery request, CancellationToken cancellationToken)
        {
            var comentario = await _projetoComentarioRepository.GetById(request.Id);

            var comentarioViewModel = new ComentarioViewModel(
                comentario.IdUsuario, 
                comentario.IdProjeto, 
                comentario.Comentario);

            return comentarioViewModel;
        }
    }
}
