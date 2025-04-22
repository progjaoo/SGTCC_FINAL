//using MediatR;

//using SistemaGestaoTCC.Application.ViewModels.ProjetoEntregaVM;
//using SistemaGestaoTCC.Core.Enums;
//using SistemaGestaoTCC.Core.Interfaces;

//namespace SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetById
//{
//    public class GetProjetoEntregaByIdQueryHandler : IRequestHandler<GetProjetoEntregaByIdQuery, ProjetoEntregaViewModel>
//    {
//        private readonly IProjetoEntregaRepository _projetoEntregaRepository;

//        public GetProjetoEntregaByIdQueryHandler(IProjetoEntregaRepository projetoEntregaRepository)
//        {
//            _projetoEntregaRepository = projetoEntregaRepository;
//        }
//        public async Task<ProjetoEntregaViewModel> Handle(GetProjetoEntregaByIdQuery request, CancellationToken cancellationToken)
//        {
//            var projetoEntrega = await _projetoEntregaRepository.GetByIdAsync(request.Id);

//            if (projetoEntrega == null)
//                throw new Exception("Entrega não encontrada");

//            var projetoEntregaViewModel = new ProjetoEntregaViewModel(projetoEntrega.Id,
//                projetoEntrega.IdProjeto,
//                projetoEntrega.Titulo,
//                projetoEntrega.Entregue,
//                projetoEntrega.DataLimite,
//                projetoEntrega.DataEnvio);

//            return projetoEntregaViewModel;
//        }
//    }
//}