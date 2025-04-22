//using MediatR;
//using SistemaGestaoTCC.Core.Interfaces;
//using SistemaGestaoTCC.Infrastructure.Repositories;

//namespace SistemaGestaoTCC.Application.Commands.ProjetoEntregasProjeto.RemoverProjetoDaEntreg
//{
//    public class DeleteProjetoEntregaCommandHandler : IRequestHandler<DeleteProjetoEntregaCommand, Unit>
//    {
//        private readonly IProjetoEntregaProjetoRepository _projetoEntregaProjetoRepository;

//        public DeleteProjetoEntregaCommandHandler(IProjetoEntregaProjetoRepository projetoEntregaProjetoRepository)
//        {
//            _projetoEntregaProjetoRepository = projetoEntregaProjetoRepository;
//        }
//        public async Task<Unit> Handle(DeleteProjetoEntregaCommand request, CancellationToken cancellationToken)
//        {
//            var projetoEntregaProj = await _projetoEntregaProjetoRepository.GetByProjectAndEntregaAsync( request.IdProjeto, request.IdEntrega);

//            if (projetoEntregaProj == null)
//            {
//                throw new Exception($"O projeto com ID {request.IdProjeto} não está vinculado a entrega {request.IdEntrega}.");
//            }

//            await _projetoEntregaProjetoRepository.DeleteProjetoEntrega(projetoEntregaProj);
//            await _projetoEntregaProjetoRepository.SaveChangesAsync();

//            return Unit.Value;
//        }
//    }
//}
