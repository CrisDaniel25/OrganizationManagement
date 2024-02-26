using AdminProSolutions.Domain.Enums;
using AdminProSolutions.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AdminProSolutions.Infrastructure.Helper
{
    public class AuthorizationManager
    {
        public static bool VerifyPasswordHash(string password, byte[] hashedpass)
        {
            try
            {
                if (password == null) throw new ArgumentNullException("password");
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
                return SHA1Encrypt.VerifyEncryption(password, hashedpass); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string CreateClaimCode(PermissionItem item, PermissionAction action)
        {
            return $"{item}.{action}";
        }

        public static bool IsUserAuthorized(AuthorizationFilterContext actionContext, PermissionItem item, PermissionAction action, string secretKey)
        {
            var authHeader = FetchFromHeader(actionContext); /* fetch authorization token from header */

            if (authHeader != null)
            {
                JwtSecurityToken? userPayloadToken = GenerateUserClaimFromJWT(authHeader.Replace("Bearer ", string.Empty), secretKey);

                if (userPayloadToken != null)
                    return userPayloadToken.Claims.Any(x => x.Value == CreateClaimCode(item, action));
                
            }

            return false;
        }

        public static JwtSecurityToken? GenerateUserClaimFromJWT(string authToken, string secretKey)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = "self",
                    ValidateAudience = true,
                    ValidAudience = "http://www.example.com",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out SecurityToken validatedToken);

                return validatedToken as JwtSecurityToken;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            try
            {
                if (password == null) throw new ArgumentNullException("password");
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
                SHA1Encrypt.Encrypt(password);
                passwordHash = SHA1Encrypt.GetHashValue();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string FetchFromHeader(AuthorizationFilterContext actionContext)
        {
            actionContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationToken);
            string requestToken = authorizationToken.ToString();

            return requestToken;
        }
    }
}
