using AdminProSolutions.API.Filters;
using AdminProSolutions.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AdminProSolutions.API.Helpers
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(PermissionItem item, PermissionAction action)
        : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { item, action };
        }
    }
}
