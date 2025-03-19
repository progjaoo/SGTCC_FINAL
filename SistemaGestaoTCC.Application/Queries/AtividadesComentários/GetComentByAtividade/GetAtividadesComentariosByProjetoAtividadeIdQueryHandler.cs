using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetComentByAtividade
{
    public class GetAtividadesComentariosByProjetoAtividadeIdQueryHandler : IRequestHandler<GetAtividadesComentariosByProjetoAtividadeIdQuery, List<AtividadeComentarioDetailsViewModel>>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;
        private readonly IUserRepository _userRepository;
        public GetAtividadesComentariosByProjetoAtividadeIdQueryHandler(IAtividadeComentarioRepository repository, IUserRepository userRepository)
        {
            _atividadeComentarioRepository = repository;
            _userRepository = userRepository;
        }

        public async Task<List<AtividadeComentarioDetailsViewModel>> Handle(GetAtividadesComentariosByProjetoAtividadeIdQuery request, CancellationToken cancellationToken)
        {
            var comentarios = await _atividadeComentarioRepository.GetAllComentarioByAtividadeIdAsync(request.IdProjetoAtividade);
            var comentariosViewModel = new List<AtividadeComentarioDetailsViewModel>();

            foreach (var comentario in comentarios)
            {
                var usuario = await _userRepository.GetById(comentario.IdUsuario); // Busca o usuário pelo IdUsuario

                if (usuario != null)
                {
                    comentariosViewModel.Add(new AtividadeComentarioDetailsViewModel(
                        comentario.IdUsuario,
                        comentario.IdAtividade,
                        comentario.Comentario,
                        usuario.Nome
                        ,comentario.Id));
                }
                else
                {
                    comentariosViewModel.Add(new AtividadeComentarioDetailsViewModel(
                        comentario.IdUsuario,
                        comentario.IdAtividade,
                        comentario.Comentario,
                        "Usuário não encontrado" 
                    ));
                }
            }
            return comentariosViewModel;
        }
    }
}
