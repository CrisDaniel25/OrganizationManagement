using AdminProSolutions.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using AdminProSolutions.Infrastructure.Helper;
using AdminProSolutions.Domain.Model;
using Microsoft.Extensions.Options;

namespace AdminProSolutions.API.Filters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly PermissionItem _item;
        private readonly PermissionAction _action;
        private readonly AppSettings _appSettings;

        public AuthorizeActionFilter(PermissionItem item, PermissionAction action, IOptions<AppSettings> appSettings)
        {
            _item = item;
            _action = action;
            _appSettings = appSettings.Value;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = AuthorizationManager.IsUserAuthorized(context, _item, _action, _appSettings.SecretKey);

            if (!isAuthorized)            
                context.Result = new UnauthorizedResult();
            
        }
    }
}
