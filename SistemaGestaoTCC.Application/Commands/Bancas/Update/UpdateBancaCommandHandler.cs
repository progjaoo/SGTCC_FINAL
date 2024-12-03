using MediatR;
using SistemaGestaoTCC.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Bancas.Update
{
    public class UpdateBancaCommandHandler : IRequestHandler<UpdateBancaCommand, Unit>
    {
        private readonly IBancaRepository _bancaRepository;
        public UpdateBancaCommandHandler(IBancaRepository bancaRepository)
        {
            _bancaRepository = bancaRepository;
        }
        public async Task<Unit>Handle(UpdateBancaCommand request, CancellationToken cancellationToken)
        {
            var banca = await _bancaRepository.GetById(request.Id);

            banca.UpdateBanca(
                request.IdProjeto,
                request.DataSeminario,
                request.Parecer,
                request.ObservacaoNotaProjeto,
                request.ObservacaoAluno,
                request.Recomendacao);

            await _bancaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
