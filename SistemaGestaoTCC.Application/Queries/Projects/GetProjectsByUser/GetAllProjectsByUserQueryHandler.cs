using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

using Newtonsoft.Json;
namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser
{
    public class GetAllProjectsQueryByUserHandler : IRequestHandler<GetProjectByUserQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryByUserHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
        {

            var projeto = await _projectRepository.GetAllByUserAsync(request.IdUsuario);

            var projectViewModel = projeto
                .Select(p => new ProjectViewModel(p.Id, p.Nome, p.Descricao, p.ProjetoTags, p.DataFim))
                .ToList();

            return projectViewModel;
        }
    }
}
