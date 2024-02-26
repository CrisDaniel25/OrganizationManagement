using AdminProSolutions.Domain.Enums;
using AdminProSolutions.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace AdminProSolutions.Domain.Interfaces.Authentication
{
    public interface IAuthetication
    {
        Users Login(string userName, string password, Users user);
        Users Register(Users user);
        IEnumerable<Claim> GetClaims(Users user);
        Users? CheckUserName(string userName);
        string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword);
        bool PasswordIsValid(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, string password);
        string ResetPasswod(string email);
    }
}
