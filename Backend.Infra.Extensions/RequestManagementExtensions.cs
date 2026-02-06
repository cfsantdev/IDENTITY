using Backend.Infra.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infra.Extensions
{
	public static class RequestManagementExtensions
    {
		public static IServiceCollection AddRequestManagementExceptionMiddleware(this IServiceCollection services)
		{
			//services.AddTransient<InternalExceptionMiddleware>();
			//services.AddTransient<DeveloperInternalExceptionMiddleware>();
			//
			return services.AddTransient<RequestManagementMiddleware>();
		}

		public static void UseRequestManagementMiddleware(this IApplicationBuilder app, string env)
		{
			app.UseMiddleware<RequestManagementMiddleware>();

			//switch (env.ToLower())
			//{
			//	case "development":
			//		app.UseMiddleware<RequestManagementMeddleware>();
			//		break;
			//
			//	case "production":
			//		app.UseMiddleware<RequestManagementMeddleware>();
			//		break;
			//
			//	default:
			//		app.UseMiddleware<RequestManagementMeddleware>();
			//		break;
			//}
		}
	}
}
