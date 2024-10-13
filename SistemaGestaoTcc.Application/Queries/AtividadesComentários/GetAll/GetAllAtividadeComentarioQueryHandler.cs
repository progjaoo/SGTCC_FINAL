using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AtividadesComentarioVM;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.AtividadesComentários.GetAll
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
            var atividade = await _atividadeComentarioRepository.GetAllAsync();

            var atividadeViewModel = atividade.Select(a => new AtividadeComentarioViewModel(
                a.IdUsuario,
                a.IdAtividade,
                a.Comentario)).ToList();

            return atividadeViewModel;
        }
    }
}
