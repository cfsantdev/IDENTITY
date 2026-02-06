using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Extensions
{
    public static class AppDbContextExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddEntityFrameworkNpgsql().AddDbContext<InventoryDbContext>(opt => {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
