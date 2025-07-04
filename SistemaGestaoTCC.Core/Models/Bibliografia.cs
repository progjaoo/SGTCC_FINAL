﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SistemaGestaoTCC.Core.Models;

public partial class Bibliografia
{
    public Bibliografia(int idUsuario, int idProjeto, string autores, string referencia, DateTime? acessadoEm)
    {
        IdUsuario = idUsuario;
        IdProjeto = idProjeto;
        Autores = autores;
        Referencia = referencia;
        AcessadoEm = acessadoEm;

        CriadoEm = DateTime.Now;
    }

    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdProjeto { get; set; }

    public string Autores { get; set; }

    public string Referencia { get; set; }

    public DateTime? AcessadoEm { get; set; }

    public DateTime CriadoEm { get; set; }

    public DateTime? EditadoEm { get; set; }

    public virtual Projeto IdProjetoNavigation { get; set; }
    public virtual Usuario IdUsuarioNavigation { get; set; }

    public void UpdateBibliografia(int idUsuario, int idProjeto, string autores, string referencia, DateTime? acessadoEm)
    {
        IdUsuario = idUsuario;
        IdProjeto = idProjeto;
        Autores = autores;
        Referencia = referencia;
        AcessadoEm = acessadoEm;

        EditadoEm = DateTime.Now;
    }
}