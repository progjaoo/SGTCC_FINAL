using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetProjetosBySeminario
{
    public class GetProjetosBySeminarioQueryHandler : IRequestHandler<GetProjetosBySeminarioQuery, List<SeminarioProjetosViewModel>>
    {
        private readonly ISeminarioRepository _seminarioRepository;

        public GetProjetosBySeminarioQueryHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }

        public async Task<List<SeminarioProjetosViewModel>> Handle(GetProjetosBySeminarioQuery request, CancellationToken cancellationToken)
        {
            var all = await _seminarioRepository.GetAllSeminarioProjeto();

            var projetos = all
                .Where(sp => sp.IdSeminario == request.IdSeminario)
                .Select(sp => new SeminarioProjetosViewModel(
                    id: sp.Id,
                    idSeminario: sp.IdSeminario,
                    idProjeto: sp.IdProjeto,
                    criadoEm: sp.CriadoEm,
                    editadoEm: sp.EditadoEm,
                    nomeProjeto: sp.IdProjetoNavigation?.Nome,
                    descricaoProjeto: sp.IdProjetoNavigation?.Descricao,
                    dataInicio: sp.IdProjetoNavigation?.DataInicio ?? DateTime.MinValue,
                    usuarios: sp.IdProjetoNavigation?.UsuarioProjetos.Select(up => new UserViewModel(
                        id: up.IdUsuario,
                        nome: up.IdUsuarioNavigation?.Nome,
                        email: up.IdUsuarioNavigation?.Email,
                        idCurso: up.IdUsuarioNavigation?.IdCurso ?? 0,
                        nomeCurso: up.IdUsuarioNavigation?.IdCursoNavigation?.Nome,
                        papel: up.IdUsuarioNavigation?.Papel ?? PapelEnum.Aluno
                    )).ToList() ?? new List<UserViewModel>()
                ))
                .ToList();

            return projetos;
        }
    }
}
