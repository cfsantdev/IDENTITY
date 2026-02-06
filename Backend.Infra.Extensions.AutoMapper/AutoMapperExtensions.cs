using AutoMapper;
using Backend.Infra.Api.ChangeRecord;
using Backend.Infra.Api.ChangeRecord.DTO;
using Backend.Infra.Api.ChangeRecord.DTO.Interfaces;
using Backend.Infra.Api.ChangeRecord.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using IChangeRecord = Backend.Infra.Api.ChangeRecord.Interfaces.IChangeRecord;

namespace Backend.Infra.Extensions.AutoMapperTools
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperAssemblies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                ConfigChangeRecordExtension(cfg);
            });

            IMapper mapper = config.CreateMapper();

            return services.AddSingleton(mapper);
        }

        public static IServiceCollection AddAutoMapperAssemblies(this IServiceCollection services, 
            List<IAutoMapperExtension> configExtensions)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                ConfigChangeRecordExtension(cfg);

                configExtensions.ForEach(extension => { 
                    extension.AddAutoMapper(cfg);
                });
            });

            IMapper mapper = config.CreateMapper();

            return services.AddSingleton(mapper);
        }

        private static void ConfigChangeRecordExtension(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<IChangeRecordDTO, IChangeRecord>().ReverseMap();
            cfg.CreateMap<IChangeRecordTrackerDTO<IChangeRecordDTO>, IChangeRecordTracker<IChangeRecord>>().ReverseMap();

            cfg.CreateMap<object?, IChangeRecordDTO>().ReverseMap();
            cfg.CreateMap<ChangeRecordDTO, ChangeRecord>().ReverseMap();
            cfg.CreateMap<ChangeRecordTrackerDTO, ChangeRecordTracker>().ReverseMap();
        }
    }
}