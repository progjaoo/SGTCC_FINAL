using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.AtividadesComentários.Create
{
    public class CreateAtividadeComentCommandHandler : IRequestHandler<CreateAtividadeComentCommand, int>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;
        private readonly IUserRepository _usuarioRepository; // Caso precise validar usuários
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository; // Caso precise validar atividades

        public CreateAtividadeComentCommandHandler(
            IAtividadeComentarioRepository atividadeComentarioRepository,
            IUserRepository usuarioRepository,
            IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _atividadeComentarioRepository = atividadeComentarioRepository;
            _usuarioRepository = usuarioRepository;
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }

        public async Task<int> Handle(CreateAtividadeComentCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetById(request.IdUsuario);
            if (usuario == null)
                throw new Exception("Usuário não encontrado!");

            var atividade = await _projetoAtividadeRepository.GetById(request.IdAtividade);
            if (atividade == null)
                throw new Exception("Atividade não encontrada!");


            var atividadeComentario = new AtividadeComentario(request.IdUsuario, request.IdAtividade, request.Comentario);

            await _atividadeComentarioRepository.AddASync(atividadeComentario);
            await _atividadeComentarioRepository.SaveChangesAsync();

            return atividadeComentario.Id; 
        }
    }
}
