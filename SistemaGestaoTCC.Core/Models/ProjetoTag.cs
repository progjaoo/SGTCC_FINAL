﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SistemaGestaoTCC.Core.Models;

public partial class ProjetoTag
{
    public int Id { get; set; }

    public int IdProjeto { get; set; }

    public string Nome { get; set; }

    public virtual Projeto IdProjetoNavigation { get; set; }
}