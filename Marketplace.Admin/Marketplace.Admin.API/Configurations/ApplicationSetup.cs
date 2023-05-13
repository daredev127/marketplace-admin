using FastExpressionCompiler;
using Mapster;
using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.MappingConfig;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using MassTransit;
using MassTransit.NewIdProviders;
using System.Reflection;

namespace Marketplace.Admin.API.Configurations
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            services.AddScoped<IContext, DatabaseContext>();
            NewId.SetProcessIdProvider(new CurrentProcessIdProvider());
            ApplyAllMappingConfigFromAssembly();
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();

            return services;
        }

        private static IEnumerable<Type> GetTypesWithInterface<TInterface>(Assembly asm)
        {
            var it = typeof(TInterface);
            return asm.GetTypes().Where(x => it.IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false });
        }

        private static void ApplyAllMappingConfigFromAssembly()
        {
            var mappers = GetTypesWithInterface<IMappingConfig>(typeof(IMappingConfig).Assembly);
            foreach (var mapperType in mappers)
            {
                var instance = (IMappingConfig)Activator.CreateInstance(mapperType)!;
                instance.ApplyConfig();
            }
        }
    }
}
