using MediatR;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto.ResponderConviteProjeto
{
    public class ResponderConviteProjetoCommandHandler : IRequestHandler<ResponderConviteProjetoCommand, Unit>
    {
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        private readonly IEmailService _emailService;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        public ResponderConviteProjetoCommandHandler(
            IUsuarioProjetoRepository usuarioProjetoRepository,
            IEmailService emailService,
            IProjectRepository projectRepository,
            IUserRepository userRepository
        )
        {
            _usuarioProjetoRepository = usuarioProjetoRepository;
            _emailService = emailService;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ResponderConviteProjetoCommand request, CancellationToken cancellationToken)
        {
            var userProject = await _usuarioProjetoRepository.GetById(request.IdConvite);

            if (userProject == null)
            {
                throw new Exception($"Convite não encontrado");
            }

            var respostaInvalida = request.Resposta != ConviteEnum.Rejeitado && request.Resposta != ConviteEnum.Aceito;
            if (respostaInvalida)
            {
                throw new Exception($"Valor de requisição inválido!");
            }

            if (userProject.EstaExpirado())
            {

                userProject.Estado = ConviteEnum.Expirado;
                await _usuarioProjetoRepository.SaveChangesAsync();
                throw new Exception($"Convite expirado!");
            }

            if (userProject.EstaRespondido())
            {
                throw new Exception($"Convite já foi respondido!");
            }

            userProject.AdicionadoEm = DateTime.Now;

            userProject.Estado = request.Resposta;

            var usuarios = await _usuarioProjetoRepository.GetAllByProjectId(userProject.IdProjeto);
            
            await _usuarioProjetoRepository.SaveChangesAsync();
            if (request.Resposta == ConviteEnum.Aceito)
            {
                userProject.AdicionadoEm = DateTime.Now;
                await this.EnviaEmail(usuarios, userProject);
            }

            return Unit.Value;
        }
        async Task<bool> EnviaEmail(List<Usuario> usuarios, UsuarioProjeto userProject)
        {
            var usuario = await _userRepository.GetById(userProject.IdUsuario);
            var projeto = await _projectRepository.GetById(userProject.IdProjeto);

            string urlProjeto = "http://localhost:5173/projeto/" + projeto.Id;
            string subject = $@"Novo Participante em {projeto.Nome}";

            string body = $@"
            <html>
                <body style='font-family: Arial, sans-serif; background-color: #f6f9fc; margin: 0; padding: 20px;'>
                    <div style='max-width: 600px; margin: auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.05);'>
                        <h2 style='color: #2c3e50;'>Confirmação de Participação no Projeto</h2>
                        <p style='font-size: 16px; color: #333333;'>
                            Olá!
                        </p>
                        <p style='font-size: 16px; color: #333333;'>
                            Informamos que <strong>{usuario.Nome}</strong> aceitou o convite para participar do projeto <strong>{projeto.Nome}</strong>.
                        </p>
                        <p style='font-size: 16px; color: #333333;'>
                            Com isso, todos os membros do projeto poderão colaborar com as atividades no projeto.
                        </p>
                        <div style='text-align: center; margin: 30px 0;'>
                            <a href='{urlProjeto}' style='background-color: #1a73e8; color: #ffffff; padding: 15px 25px; text-decoration: none; font-size: 16px; border-radius: 6px; display: inline-block;'>
                                Acessar Projeto
                            </a>
                        </div>
                        <hr style='margin: 30px 0; border: none; border-top: 1px solid #e0e0e0;' />
                        <p style='font-size: 12px; color: #999999; text-align: center;'>
                            © {DateTime.Now.Year} SGTCC. Todos os direitos reservados.<br />
                            Este e-mail foi enviado automaticamente, por favor, não responda.
                        </p>
                    </div>
                </body>
            </html>";

            foreach (var usuarioEmail in usuarios)
            {
                bool emailSent = await _emailService.SendEmailAsync(usuarioEmail.Email, subject, body);
                // if (!emailSent)
                // {
                //     throw new Exception("Falha ao enviar o e-mail");
                // }
            }

            return true;
        }
    }

}