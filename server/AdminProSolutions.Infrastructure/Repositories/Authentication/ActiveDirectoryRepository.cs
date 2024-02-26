using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Interfaces.Authentication;
using AdminProSolutions.Domain.Model;
using Microsoft.Extensions.Options;
using System.DirectoryServices;
using System.Reflection.PortableExecutable;

namespace AdminProSolutions.Infrastructure.Repositories.Authentication
{
    public class ActiveDirectoryRepository : IActiveDirectory
    {

        private readonly AppSettings _appSettings;

        public ActiveDirectoryRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Users? GetUserInfo(string username)
        {

            Users userInfo = new();
            string[] attributes = new string[] { "name", "mail", "telephoneNumber", "sAMAccountName", "userAccountControl" };
            string filter = $"(sAMAccountName={username})";

            try
            {
                System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(_appSettings.LDAP.Url, _appSettings.LDAP.BindDn, _appSettings.LDAP.BindCredentials, AuthenticationTypes.Secure);
                DirectorySearcher Dsearch = new DirectorySearcher(entry, username);

                var srch = new DirectorySearcher(entry, filter);

                srch.PropertiesToLoad.AddRange(attributes);

                var result = srch.FindOne();

                if (result == null)
                    return null;

                if (result.Properties.Contains("mail"))
                    userInfo.UserEmail = result.Properties["mail"][0].ToString();

                if (result.Properties.Contains("name"))
                    userInfo.UserName = result.Properties["name"][0].ToString();

                if (result.Properties.Contains("telephoneNumber"))
                    userInfo.UserPhone = result.Properties["telephoneNumber"][0].ToString();

                if (result.Properties.Contains("sAMAccountName"))
                    userInfo.UserLogin = result.Properties["sAMAccountName"][0].ToString();

                return userInfo;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerifyPassword(string username, string password)
        {
            try
            {
                System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(_appSettings.LDAP.Url, username, password, AuthenticationTypes.Secure);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
