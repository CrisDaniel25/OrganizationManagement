using SendGrid;
using SendGrid.Helpers.Mail;
using AdminProSolutions.Domain.Dtos.Messenger;
using AdminProSolutions.Domain.Interfaces.Messenger;
using Microsoft.Extensions.Configuration;

namespace AdminProSolutions.Infrastructure.Repositories.Messenger
{
    public class EmailRepository : IEmail
    {
        private readonly string name_info = "Servicios Integrales de Desarrollo Empresarial";
        private readonly string email_info = "info@sidedominicana.com";
        private readonly string _subject_tecnologia = "Formulario de Solicitudes - Sitio Web <<sidedominicana.com>>";
        private readonly string _email_tecnologia = "tecnologia@sidedominicana.com";
        private IConfiguration _configuration;
        //private EmailUtilities _emailUtilities = new EmailUtilities();

        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Método que envia un correo al Solicitante de parte de Side
        public async Task SendEmailToClient(EmailDto email)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email_info, name_info);
            var subject = email.Subject + " - Respuesta";
            var to = new EmailAddress(email.Mail, email.Name);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
        #endregion 
    }
}
