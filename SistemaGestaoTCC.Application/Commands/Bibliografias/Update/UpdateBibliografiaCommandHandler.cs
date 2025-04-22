using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Bibliografias.Update
{
    public class UpdateBibliografiaCommandHandler : IRequestHandler<UpdateBibliografiaCommand, Unit>
    {
        private readonly IBibliografiaRepository _bibliografiaRepository;
        public UpdateBibliografiaCommandHandler(IBibliografiaRepository bibliografiaRepository)
        {
            _bibliografiaRepository = bibliografiaRepository;
        }
        public async Task<Unit> Handle(UpdateBibliografiaCommand request, CancellationToken cancellationToken)
        {
            var bibliografia = await _bibliografiaRepository.GetById(request.Id);

            if (bibliografia == null)
            {
                throw new Exception("Anotação não encontrada");
            }
            bibliografia.UpdateBibliografia(bibliografia.IdUsuario, bibliografia.IdProjeto, bibliografia.Autores, bibliografia.Referencia);

            await _bibliografiaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}