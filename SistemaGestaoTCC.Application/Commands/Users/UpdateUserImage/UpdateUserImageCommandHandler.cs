using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Application.Helpers;
using SistemaGestaoTCC.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestaoTCC.Application.Commands.Users.UpdateUserImage
{
    public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IArquivoRepository _arquivoRepository;
        private readonly IAuthService _authService;
        private readonly SGTCCContext _dbcontext;
        public UpdateUserImageCommandHandler(IUserRepository userRepository, IArquivoRepository arquivoRepository, IAuthService authService, SGTCCContext dbcontext)
        {
            _userRepository = userRepository;
            _arquivoRepository = arquivoRepository;
            _authService = authService;
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            var extensaoArquivo = Path.GetExtension(request.File.FileName);

            var idArquivo = 0;
            if (user.IdImagem == null)
            {
                var arquivo = new Arquivo(
                    request.File.FileName,
                    request.FolderName,
                    (int)request.File.Length,
                    extensaoArquivo
                );

                var novoArquivo = await _arquivoRepository.AddAsync(arquivo);

                idArquivo = novoArquivo.Id;
                _dbcontext.Entry(user).Property(x => x.IdImagem).IsModified = true;

                user.UpdateImage(idArquivo);
            }
            else
            {
                var arquivo = await _arquivoRepository.GetByIdAsync((int)user.IdImagem);

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

            await _userRepository.SaveChangesAsync();
            // await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
