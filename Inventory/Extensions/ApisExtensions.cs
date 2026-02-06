using Inventory.Models;
using Inventory.Models.Interfaces;
using Inventory.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Extensions
{
    public static class ApisExtensions
    {
		public static IServiceCollection AddApisExtensions(this IServiceCollection services, IApis apis)
		{
			services.Add(new ServiceDescriptor(typeof(Apis), apis));

			return services.AddScoped<IApis, Apis>(x => x.GetRequiredService<Apis>());
		}
	}
}
