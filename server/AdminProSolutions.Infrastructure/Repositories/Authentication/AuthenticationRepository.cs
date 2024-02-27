using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Enums;
using AdminProSolutions.Domain.Interfaces.Authentication;
using AdminProSolutions.Infrastructure.Data;
using AdminProSolutions.Infrastructure.Repositories.Base;
using AdminProSolutions.Infrastructure.Helper;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using AdminProSolutions.Domain.Model;

namespace AdminProSolutions.Infrastructure.Repositories.Authentication
{
    public class AuthenticationRepository : Repository<IAuthetication>, IAuthetication
    {
        private readonly AppSettings _appSettings;

        public AuthenticationRepository(DataContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
        }

        public Users Login(string userName, string password, Users user)
        {
            try
            {               
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

                ClaimsIdentity claims = new ClaimsIdentity();
                claims.AddClaims(GetClaims(user));
                user.Claims = claims.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = "http://www.example.com",
                    Issuer = "self",
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(_appSettings.TokenValidDuration),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                /* authentication successful */
                if (user.PasswordFailedQuantity > 0)
                {
                    /* --- RESET --- */
                    user.PasswordFailedQuantity = 0;
                    this._context.Users.Update(user);
                    this._context.SaveChanges();
                }

                return new Users
                {
                    UserId = user.UserId,
                    UserLogin = user.UserLogin,
                    UserName = user.UserName,
                    Token = user.Token,
                    Claims = user.Claims,
                    UserPasswordHasBeenReset = user.UserPasswordHasBeenReset,
                    TypeAutentication = user.TypeAutentication
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users Register(Users user)
        {
            try
            {
                return new Users();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Claim> GetClaims(Users user)
        {

            try
            {
                ClaimsIdentity claims = new ClaimsIdentity();
                String claimVal = string.Empty;

                claims.AddClaim(new Claim(ClaimTypes.Name, user.UserId.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Email, string.IsNullOrEmpty(user.UserEmail) ? user.UserLogin : user.UserEmail));
                
                var roles = user.GroupUsers.Select(x => x.GroupId);

                var roleMenu = _context.GroupFormsAccessTypes
                    .Include(r => r.FormAccessType)
                    .Where(m => roles.Contains(m.GroupId) && m.Group.GroupStatus == GroupStatusTypeEnum.ACTIVE).ToList();

                foreach (var mp in roleMenu)
                {
                    claimVal = AuthorizationManager.CreateClaimCode((PermissionItem)mp.FormAccessType.FormId, (PermissionAction)mp.FormAccessType.AccessTypeId);

                    if (!claims.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == claimVal))
                        claims.AddClaim(new Claim(ClaimTypes.Role, claimVal));

                }

                return claims.Claims;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users? CheckUserName(string userName)
        {
            try
            {
                var record = _context.Users.Where(u => u.UserLogin == userName).FirstOrDefault();

                if (record != null) return null;

                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword)
        {
            try
            {
                const int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;
                const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
                const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string NUMERIC_CHARACTERS = "0123456789";
                const string SPECIAL_CHARACTERS = @"!#$%&*@\";
                const string SPACE_CHARACTER = " ";
                const int PASSWORD_LENGTH_MIN = 8;
                const int PASSWORD_LENGTH_MAX = 128;

                if (lengthOfPassword < PASSWORD_LENGTH_MIN || lengthOfPassword > PASSWORD_LENGTH_MAX)                
                    return "Password length must be between 8 and 128.";                

                string characterSet = "";

                if (includeLowercase)
                characterSet += LOWERCASE_CHARACTERS;

                if (includeUppercase)
                characterSet += UPPERCASE_CHARACTERS;

                if (includeNumeric)
                    characterSet += NUMERIC_CHARACTERS;
                

                if (includeSpecial)                
                    characterSet += SPECIAL_CHARACTERS;
                

                if (includeSpaces)
                    characterSet += SPACE_CHARACTER;
                

                char[] password = new char[lengthOfPassword];
                int characterSetLength = characterSet.Length;

                Random random = new Random();
                for (int characterPosition = 0; characterPosition < lengthOfPassword; characterPosition++)
                {
                    password[characterPosition] = characterSet[random.Next(characterSetLength - 1)];

                    bool moreThanTwoIdenticalInARow =
                        characterPosition > MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS &&
                        password[characterPosition] == password[characterPosition - 1] &&
                        password[characterPosition - 1] == password[characterPosition - 2];

                    if (moreThanTwoIdenticalInARow)                    
                        characterPosition--;
                }

                return string.Join(null, password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PasswordIsValid(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, string password)
        {
            try
            {
                const string REGEX_LOWERCASE = @"[a-z]";
                const string REGEX_UPPERCASE = @"[A-Z]";
                const string REGEX_NUMERIC = @"[\d]";
                const string REGEX_SPECIAL = @"([!#$%&*@\\])+";
                const string REGEX_SPACE = @"([ ])+";

                bool lowerCaseIsValid = !includeLowercase || (includeLowercase && Regex.IsMatch(password, REGEX_LOWERCASE));
                bool upperCaseIsValid = !includeUppercase || (includeUppercase && Regex.IsMatch(password, REGEX_UPPERCASE));
                bool numericIsValid = !includeNumeric || (includeNumeric && Regex.IsMatch(password, REGEX_NUMERIC));
                bool symbolsAreValid = !includeSpecial || (includeSpecial && Regex.IsMatch(password, REGEX_SPECIAL));
                bool spacesAreValid = !includeSpaces || (includeSpaces && Regex.IsMatch(password, REGEX_SPACE));

                return lowerCaseIsValid && upperCaseIsValid && numericIsValid && symbolsAreValid && spacesAreValid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ResetPasswod(string email)
        {
            try
            {
                var user = _context.Users.Where(x => x.UserEmail == email && x.UserStatus == UserStatusTypeEnum.ACTIVE).FirstOrDefault();
                if (user != null)
                {
                    var newPassword = GeneratePassword(true, true, true, true, false, 10);
                    byte[] passwordHash = Array.Empty<byte>();
                    AuthorizationManager.CreatePasswordHash(newPassword, out passwordHash);

                    user.HashPassword = passwordHash;
                    user.UserPasswordHasBeenReset = true;

                    _context.Users.Attach(user);
                    _context.Entry(user).Property(x => x.HashPassword).IsModified = true;
                    _context.Entry(user).Property(x => x.UserPasswordHasBeenReset).IsModified = true;

                    _context.SaveChanges();

                    return newPassword;
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}