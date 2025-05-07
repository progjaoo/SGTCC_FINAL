using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto
{
    public class AddUserInProjectCommandHandler : IRequestHandler<AddUserInProjectCommand, int>
    {
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        private readonly IEmailService _emailService;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        public AddUserInProjectCommandHandler(
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
        public async Task<int> Handle(AddUserInProjectCommand request, CancellationToken cancellationToken)
        {
            var usuariosAtivos = await _usuarioProjetoRepository.GetAllUsersActiveInProjectById(request.IdProjeto);
            foreach (var usuarioAtivo in usuariosAtivos)
            {
                if (usuarioAtivo.Id == request.IdUsuario) {
                    throw new Exception("Usuário já faz parte do projeto");
                }

            }

            var userProject = new UsuarioProjeto(request.IdUsuario, request.IdProjeto, request.Funcao);

            await _usuarioProjetoRepository.AddASync(userProject);
            await _usuarioProjetoRepository.SaveChangesAsync();

            var projeto = await _projectRepository.GetById(request.IdProjeto);
            var usuario = await _userRepository.GetById(request.IdUsuario);

            string urlConvites = "http://localhost:5173/convites";
            string subject = "Convite para participar de Projeto";

            string body = $@"
            <html>
                <body style='font-family: Arial, sans-serif; background-color: #f6f9fc; margin: 0; padding: 20px;'>
                    <div style='max-width: 600px; margin: auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.05);'>
                        <h2 style='color: #2c3e50;'>Convite para Participar de um Projeto</h2>
                        <p style='font-size: 16px; color: #333333;'>
                            Olá!
                        </p>
                        <p style='font-size: 16px; color: #333333;'>
                            Você foi convidado(a) para participar de do projeto {projeto.Nome} no SGTCC. Clique no botão abaixo para responder o convite e começar a colaborar:
                        </p>
                        <div style='text-align: center; margin: 30px 0;'>
                            <a href='{urlConvites}' style='background-color: #1a73e8; color: #ffffff; padding: 15px 25px; text-decoration: none; font-size: 16px; border-radius: 6px; display: inline-block;'>
                                Gerenciar Convites
                            </a>
                        </div>
                        <p style='font-size: 14px; color: #555555;'>
                            Se você não esperava este convite, pode simplesmente ignorar este e-mail, ou Rejeitar o Convite no mesmo acesso.
                        </p>
                        <hr style='margin: 30px 0; border: none; border-top: 1px solid #e0e0e0;' />
                        <p style='font-size: 12px; color: #999999; text-align: center;'>
                            © {DateTime.Now.Year} SGTCC. Todos os direitos reservados.<br />
                            Este e-mail foi enviado automaticamente, por favor, não responda.
                        </p>
                    </div>
                </body>
            </html>";

            bool emailSent = await _emailService.SendEmailAsync(usuario.Email, subject, body);
            if (!emailSent)
            {
                throw new Exception("Falha ao enviar o e-mail");
            }

            return userProject.Id;
        }
    }
}