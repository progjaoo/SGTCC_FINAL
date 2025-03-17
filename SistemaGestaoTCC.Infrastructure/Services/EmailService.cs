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

            public EmailService()
            {
                _smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("joaoevbeijo@gmail.com", "qvvv lcxl cyvd gtbf"),
                    EnableSsl = true
                };
            }

            public async Task<bool> SendEmailAsync(string recipientEmail, string subject, string body)
            {
                try
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("joaoevbeijo@gmail.com"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false
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
