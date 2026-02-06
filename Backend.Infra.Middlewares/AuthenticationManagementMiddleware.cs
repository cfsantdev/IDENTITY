using Backend.Infra.Identity.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Infra.Middlewares
{
    public class AuthenticationManagementMiddleware : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IdentityDbContext _context;

        public AuthenticationManagementMiddleware(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            if (AllowAnonymous(filterContext))
                return;

            string? authorization = GetHeaders(filterContext.HttpContext)?.Find(x => x.Key == "Authorization").Value.ToString().Replace("Bearer ", string.Empty);
            if (authorization == null || authorization == default)
                throw new Exception("RequestManagementMeddleware(AuthorizationManagement) throw this exception: No request header 'Authorization' to read.");

            JwtSecurityToken? token = Token.Services.ReadToken(authorization);
            if (token == null || token == default)
                throw new Exception("Invalid token.");

            var claim = token.Claims.SingleOrDefault(x => x.Type.Equals(ClaimTypes.Hash));
            if (claim == null || claim == default)
                throw new Exception("Invalid claim.");

            var hash = claim.Value;
            if (string.IsNullOrEmpty(hash) || string.IsNullOrWhiteSpace(hash))
                throw new Exception("Invalid claim value.");

            var profile = _context.Profile.SingleOrDefault(x => x.HashAuth.Equals(hash));
            if (profile == null || profile == default)
                throw new Exception("Invalid profile.");

            if (DateTime.UtcNow > token.ValidTo)
                throw new Exception("Token expires in UTC: " + token.ValidTo + " — Local: " + token.ValidTo.ToLocalTime() + ".");
        }

        private List<KeyValuePair<string, StringValues>>? GetHeaders(HttpContext context) => 
            context.Request.Headers.ToList();

        private bool AllowAnonymous(AuthorizationFilterContext filterContext) => 
            filterContext.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute));
    }
}
