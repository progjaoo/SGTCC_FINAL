﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsPending
{
    public class GetAllProjectsPendingQueryHandler : IRequestHandler<GetProjectPendingQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsPendingQueryHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectPendingQuery request, CancellationToken cancellationToken)
        {

            var projeto = await _projectRepository.GetAllPendingAsync();

            var projectViewModel = projeto
                .Select(p => new ProjectViewModel(p.Id, p.Nome, p.Descricao, p.ProjetoTags, p.DataFim))
                .ToList();

            return projectViewModel;
        }
    }
}
