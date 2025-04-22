//using MediatR;
//using SistemaGestaoTCC.Core.Interfaces;

//namespace SistemaGestaoTCC.Application.Commands.ProjetoEntregasProjeto.AddProjetoEntrega
//{
//    public class AddProjetoEmEntregaCommandHandler : IRequestHandler<AddProjetoEmEntregaCommand, int>
//    {
//        private readonly IProjetoEntregaProjetoRepository _projetoEntregaProjetoRepository;

//        public AddProjetoEmEntregaCommandHandler(IProjetoEntregaProjetoRepository projetoEntregaProjetoRepository)
//        {
//            _projetoEntregaProjetoRepository = projetoEntregaProjetoRepository;
//        }

//        public async Task<int> Handle(AddProjetoEmEntregaCommand request, CancellationToken cancellationToken)
//        {
//            var projetoEntregaProjeto = new Core.Models.ProjetoEntregaProjeto(request.IdProjeto, request.IdEntrega);

//            await _projetoEntregaProjetoRepository.AddAsync(projetoEntregaProjeto);
//            await _projetoEntregaProjetoRepository.SaveChangesAsync();

//            return projetoEntregaProjeto.Id;
//        }
//    }
//}
