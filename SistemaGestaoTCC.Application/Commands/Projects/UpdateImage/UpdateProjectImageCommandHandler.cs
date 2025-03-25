using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Application.Helpers;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Projects.UpdateImage
{
    public class UpdateProjectImageCommandHandler : IRequestHandler<UpdateProjectImageCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IArquivoRepository _arquivoRepository;
        private readonly IAuthService _authService;

        public UpdateProjectImageCommandHandler(IProjectRepository projectRepository, IArquivoRepository arquivoRepository, IAuthService authService)
        {
            _projectRepository = projectRepository;
            _arquivoRepository = arquivoRepository;
            _authService = authService;
        }

        public async Task<Unit> Handle(UpdateProjectImageCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);
            var extensaoArquivo = Path.GetExtension(request.File.FileName);

            var idArquivo = 0;
            if (project.IdImagem == null)
            {
                var arquivo = new Arquivo(
                    request.File.FileName,
                    request.FolderName,
                    (int)request.File.Length,
                    extensaoArquivo
                );

                var novoArquivo = await _arquivoRepository.AddAsync(arquivo);

                idArquivo = novoArquivo.Id;
                project.UpdateImage(idArquivo);
            }
            else
            {
                var arquivo = await _arquivoRepository.GetByIdAsync((int)project.IdImagem);

                ArquivoHelper.DeletarArquivo(arquivo.Diretorio, arquivo.Id, arquivo.Extensao);

                arquivo.Update(
                    request.File.FileName,
                    request.FolderName,
                    (int)request.File.Length,
                    extensaoArquivo
                );

                await _arquivoRepository.SaveChangesAsync();
                idArquivo = arquivo.Id;
            }

            await ArquivoHelper.SalvarArquivo(request.File, request.FolderName, idArquivo);

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
