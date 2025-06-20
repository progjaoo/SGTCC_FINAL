﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using SistemaGestaoTCC.Core.Enums;
using System;
using System.Collections.Generic;

namespace SistemaGestaoTCC.Core.Models;

public partial class NotaDocumentoAluno
{
    public NotaDocumentoAluno(int idAvaliadorBanca, int idCampo, int? idAluno, int nota, NotaTipoEnum tipo)
    {
        IdAvaliadorBanca = idAvaliadorBanca;
        IdCampo = idCampo;
        IdAluno = idAluno;
        Nota = nota;
        Tipo = tipo;

        CriadoEm = DateTime.Now;
    }
    public int Id { get; set; }

    public int IdAvaliadorBanca { get; set; }

    public int IdCampo { get; set; }

    public int? IdAluno { get; set; }

    public int Nota { get; set; }

    public NotaTipoEnum Tipo { get; set; }

    public DateTime CriadoEm { get; set; }

    public virtual Usuario IdAlunoNavigation { get; set; }

    public virtual AvaliadorBanca IdAvaliadorBancaNavigation { get; set; }

    public virtual CampoDocumentoAvaliacaoAluno IdCampoNavigation { get; set; }
    public void UpdateNotaDocumento(int idAvaliadorBanca, int idCampo, int? idAluno, int nota, NotaTipoEnum tipo)
    {
        IdAvaliadorBanca = idAvaliadorBanca;
        IdCampo = idCampo;
        IdAluno = idAluno;
        Nota = nota;
        Tipo = tipo;
    }
}