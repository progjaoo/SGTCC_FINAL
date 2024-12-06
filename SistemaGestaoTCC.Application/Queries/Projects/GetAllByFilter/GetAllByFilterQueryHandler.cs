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

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser
{
    public class GetAllByFilterQueryHandler : IRequestHandler<GetAllByFilterQuery, List<ProjectFilterViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllByFilterQueryHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectFilterViewModel>> Handle(GetAllByFilterQuery request, CancellationToken cancellationToken)
        {
            var projeto = await _projectRepository.GetAllByFilterAsync(request.TipoFiltro, request.Filtro, request.TipoOrdenacao, request.Ano);

            var projectViewModel = projeto
                .Select(p => new ProjectFilterViewModel(p.Id, p.Nome, p.Descricao, p.UsuarioProjetos, p.ProjetoTags, p.DataFim))
                .ToList();

            return projectViewModel;
        }
    }
}
