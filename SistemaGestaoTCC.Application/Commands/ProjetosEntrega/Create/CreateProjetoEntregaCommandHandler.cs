//using MediatR;
//using Microsoft.AspNetCore.Http;

//using SistemaGestaoTCC.Core.Enums;
//using SistemaGestaoTCC.Core.Interfaces;
//using SistemaGestaoTCC.Core.Models;
//using System.Security.Claims;

//namespace SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Create
//{
//    public class CreateProjetoEntregaCommandHandler : IRequestHandler<CreateProjetoEntregaCommand, int>
//    {
//        private readonly IProjetoEntregaRepository _projetoEntregaRepository;
//        private readonly IProjetoEntregaProjetoRepository _projetoEntregaProjetoRepository;
//        private readonly IProjectRepository _projetoRepository;


//        public CreateProjetoEntregaCommandHandler(
//            IProjetoEntregaRepository projetoEntregaRepository,
//            IProjetoEntregaProjetoRepository projetoEntregaProjetoRepository,
//            IProjectRepository projetoRepository
//            )
//        {
//            _projetoEntregaRepository = projetoEntregaRepository;
//            _projetoEntregaProjetoRepository = projetoEntregaProjetoRepository;
//            _projetoRepository = projetoRepository;
//        }
//        public async Task<int> Handle(CreateProjetoEntregaCommand request, CancellationToken cancellationToken)
//        {

//            var projeto = await _projetoRepository.GetById(request.IdProjeto);
//            if (projeto == null)
//            {
//                throw new Exception("Projeto não encontrado!");
//            }

//            var entrega = new ProjetoEntrega(request.IdProjeto, request.Titulo, request.DataLimite, request.Entregue);
//            await _projetoEntregaRepository.AddAsync(entrega);
//            await _projetoEntregaRepository.SaveChangesAsync();

//            //var entregaProjeto = new ProjetoEntregaProjeto(entrega.Id, request.IdProjeto);
//            //await _projetoEntregaProjetoRepository.AddAsync(entregaProjeto);
//            //await _projetoEntregaProjetoRepository.SaveChangesAsync();   //CRIEI ESSA CLASSE/TABELA NO BANCO PARA ADICIONAR PROJETO DENTRO DA ENTREGAS

//            return entrega.Id;
//        }
//    }
//}