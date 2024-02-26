using AdminProSolutions.Domain.Entities.Authentication;

namespace AdminProSolutions.Domain.Interfaces.Authentication
{
    public interface IActiveDirectory
    {
        Users? GetUserInfo(string username);
        bool VerifyPassword(string username, string password);
    }
}
