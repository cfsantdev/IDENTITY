using Entities.Public.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Public.Extensions
{
    public static class RequestManagementExtencions
    {
		public static IServiceCollection AddRequestManagementExceptionMiddleware(this IServiceCollection services)
		{
			//services.AddTransient<InternalExceptionMiddleware>();
			//services.AddTransient<DeveloperInternalExceptionMiddleware>();
			//
			return services.AddTransient<RequestManagementMeddleware>();
		}

		public static void UseRequestManagementMiddleware(this IApplicationBuilder app, string env)
		{
			app.UseMiddleware<RequestManagementMeddleware>();

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
