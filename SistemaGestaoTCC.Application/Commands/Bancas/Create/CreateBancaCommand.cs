﻿using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Bancas.Create
{
    public class CreateBancaCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public DateTime DataSeminario { get; set; }
        public string ObservacaoNotaProjeto { get; set; }
        public string ObservacaoAluno { get; set; }
        public string Recomendacao { get; set; }
    }
}
