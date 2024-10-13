using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AtividadesComentarioVM;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.AtividadesComentários.GetById
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
            var atividade = await _atividadeComentarioRepository.GetById(request.Id);

            if (atividade == null)
                throw new Exception("Comentario em atividade não encontrado!");

            var atividadeViewModel = new AtividadeComentarioViewModel(
                atividade.IdUsuario,
                atividade.IdAtividade,
                atividade.Comentario);

            return atividadeViewModel;
        }
    }
}