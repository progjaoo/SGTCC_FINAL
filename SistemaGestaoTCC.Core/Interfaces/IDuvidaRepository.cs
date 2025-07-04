﻿using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IDuvidaRepository
    {
        Task<List<Duvida>> GetAllAsync();
        Task<List<Duvida>> GetAllByCursoAsync(int idCurso);
        Task<Duvida?> GetByIdAsync(int id);
        Task<List<Duvida>> GetByProjetoIdAsync(int idProjeto);
        Task<List<Duvida>> GetByProjetoAndAtendidaAsync(int idProjeto, RespotaDuvidaEnum atendida);
        Task<List<Duvida>> GetByUsuarioIdAsync(int idUsuario);
        Task MarcarComoAtendidaAsync(int idDuvida);
        Task MarcarComoNaoAtendidaAsync(int idDuvida);

        Task AddAsync(Duvida duvida);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
