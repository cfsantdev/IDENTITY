using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Backend.Infra.Extensions
{
    public static class IdentityAssembliesExtensions
    {
        public static IServiceCollection AddIdentityAssemblies(this IServiceCollection services, IMvcBuilder builder)
        {
            var BackendInfraIdentityAssembly = Assembly.Load("Backend.Infra.Identity");
            if (BackendInfraIdentityAssembly == null || BackendInfraIdentityAssembly == default)
            {
                throw new Exception("Failed to load 'BackendInfraApiCrudAssembly' assembly.");
            }

            var BackendInfraApiCrudAssembly = Assembly.Load("Backend.Infra.Api.Crud");
            if (BackendInfraApiCrudAssembly == null || BackendInfraApiCrudAssembly == default)
            {
                throw new Exception("Failed to load 'BackendInfraApiCrudAssembly' assembly.");
            }

            var BackendInfraApiRecordAssembly = Assembly.Load("Backend.Infra.Api.ChangeRecord");
            if (BackendInfraApiRecordAssembly == null || BackendInfraApiRecordAssembly == default)
            {
                throw new Exception("Failed to load 'BackendInfraApiRecordAssembly' assembly.");
            }

            var BackendInfraApiRecordInterfacesAssembly = Assembly.Load("Backend.Infra.Api.ChangeRecord.Interfaces");
            if (BackendInfraApiRecordInterfacesAssembly == null || BackendInfraApiRecordInterfacesAssembly == default)
            {
                throw new Exception("Failed to load 'BackendInfraApiRecordInterfacesAssembly' assembly.");
            }

            builder.ConfigureApplicationPartManager(apm => {
                apm.ApplicationParts.Add(new AssemblyPart(BackendInfraIdentityAssembly));
                apm.ApplicationParts.Add(new AssemblyPart(BackendInfraApiCrudAssembly));
                apm.ApplicationParts.Add(new AssemblyPart(BackendInfraApiRecordAssembly));
                apm.ApplicationParts.Add(new AssemblyPart(BackendInfraApiRecordInterfacesAssembly));
            });

            return services;
        }
    }
}
