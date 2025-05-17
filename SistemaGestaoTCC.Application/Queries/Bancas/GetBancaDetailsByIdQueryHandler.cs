using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Bancas
{
    public class GetBancaDetailsByIdQueryHandler : IRequestHandler<GetBancaDetailsByIdQuery, BancaProjetoDetalhesDetalhesViewModel>
    {
        private readonly IBancaRepository _bancaRepository;

        public GetBancaDetailsByIdQueryHandler(IBancaRepository bancaRepository)
        {
            _bancaRepository = bancaRepository;
        }
        public async Task<BancaProjetoDetalhesDetalhesViewModel> Handle(GetBancaDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var banca = await _bancaRepository.GetById(request.IdBanca);

            if (banca == null)
                return null;

            var projeto = banca.IdProjetoNavigation;

            var participantes = projeto.UsuarioProjetos
                .Select(up => up.IdUsuarioNavigation.Nome)
                .ToList();

            var avaliadores = banca.AvaliadorBancas
                .Select(ab => ab.IdUsuarioNavigation.Nome)
                .ToList();

            var notas = banca.AvaliadorBancas
                .SelectMany(ab => ab.NotaFinalAlunos)
                .Select(nota => new NotaFinalAlunoViewModel
                {
                    NomeAluno = nota.IdAlunoNavigation.Nome,
                    Nota = nota.Nota
                })
                .ToList();

            return new BancaProjetoDetalhesDetalhesViewModel
            {
                NomeProjeto = projeto.Nome,
                Descricao = projeto.Descricao,
                ObservacaoNotaProjeto = banca.ObservacaoNotaProjeto,
                ObservacaoAluno = banca.ObservacaoAluno,
                Recomendacao = banca.Recomendacao,
                Participantes = participantes,
                NotasFinais = notas,
                Avaliadores = avaliadores
            };
        }
    }

}
