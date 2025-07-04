﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using SistemaGestaoTCC.Core.Enums;
using System;
using System.Collections.Generic;

namespace SistemaGestaoTCC.Core.Models;

public partial class Banca
{
    public Banca(int idProjeto, DateTime dataSeminario,
       string observacaoNotaProjeto, string observacaoAluno, string recomendacao)
    {
        IdProjeto = idProjeto;
        DataSeminario = dataSeminario;
        Parecer = ParecerBancaEnum.Created;
        ObservacaoNotaProjeto = observacaoNotaProjeto;
        ObservacaoAluno = observacaoAluno;
        Recomendacao = recomendacao;

        CriadoEm = DateTime.Now;
    }
    public int Id { get; set; }

    public int IdProjeto { get; set; }

    public DateTime DataSeminario { get; set; }

    public ParecerBancaEnum Parecer { get; set; }

    public string ObservacaoNotaProjeto { get; set; }

    public string ObservacaoAluno { get; set; }

    public string Recomendacao { get; set; }

    public DateTime CriadoEm { get; set; }

    public virtual ICollection<AvaliadorBanca> AvaliadorBancas { get; set; } = new List<AvaliadorBanca>();

    public virtual Projeto IdProjetoNavigation { get; set; }
    public void UpdateBanca(int idProjeto, DateTime dataSeminario,
       string observacaoNotaProjeto, string observacaoAluno, string recomendacao)
    {
        IdProjeto = idProjeto;
        DataSeminario = dataSeminario;
        ObservacaoNotaProjeto = observacaoNotaProjeto;
        ObservacaoAluno = observacaoAluno;
        Recomendacao = recomendacao;
    }
}