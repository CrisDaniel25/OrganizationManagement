using AdminProSolutions.Domain.Dtos.Messenger;

namespace AdminProSolutions.Domain.Interfaces.Messenger
{
    public interface IEmail
    {
        Task SendEmailToClient(EmailDto email);
    }
}
