using Backend.Infra.Identity.DbContext;
using Backend.Infra.Middlewares.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infra.Middlewares
{
    public class RequestManagementMiddleware : IMiddleware
    {
        private readonly ILogger<RequestManagementMiddleware> _logger;
        private readonly IdentityDbContext _context;

        public RequestManagementMiddleware(ILogger<RequestManagementMiddleware> logger, IdentityDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex}");

                await DeveloperInternalExceptionMiddleware.HandleExceptionAsync(context, ex);
            }
        }
    }
}
