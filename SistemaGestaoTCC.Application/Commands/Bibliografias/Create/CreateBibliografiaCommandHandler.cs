using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Bibliografias.Create
{
    public class CreateBibliografiaCommandHandler : IRequestHandler<CreateBibliografiaCommand, int>
    {
        private readonly IBibliografiaRepository _bibliografiaRepository;
        public CreateBibliografiaCommandHandler(IBibliografiaRepository bibliografiaRepository)
        {
            _bibliografiaRepository = bibliografiaRepository;
        }
        public async Task<int> Handle(CreateBibliografiaCommand request, CancellationToken cancellationToken)
        {
            var bibliografia = new Bibliografia(request.IdUsuario,request.IdProjeto, request.Autores, request.Referencia, request.AcessadoEm);

            await _bibliografiaRepository.AddAsync(bibliografia);
            await _bibliografiaRepository.SaveChangesAsync();

            return bibliografia.Id;
        }
    }

}
