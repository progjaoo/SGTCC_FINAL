using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Infrastructure.Services
{

    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string emailUser;
        private readonly string emailPass;

        public EmailService(IConfiguration configuration)
        {
            emailUser = configuration["Email:User"] ?? "";
            emailPass = configuration["Email:Password"] ?? "";

            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailUser, emailPass),
                EnableSsl = true
            };
        }

        public async Task<bool> SendEmailAsync(string recipientEmail, string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailUser),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(recipientEmail);

                await _smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o e-mail: {ex.Message}");
                return false;
            }
        }
    }
}
