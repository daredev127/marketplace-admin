using Marketplace.Admin.Domain.Entities.Common;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace Marketplace.Admin.API.Configurations
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Marketplace.Admin.Api",
                        Version = "v1",
                        Description = "Marketplace API",
                    });
                c.DescribeAllParametersInCamelCase();
                c.OrderActionsBy(x => x.RelativePath);

                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }

                // Maps all structured ids to the guid type to show correctly on swagger
                var allGuids = typeof(IGuid).Assembly.GetTypes().Where(type => typeof(IGuid).IsAssignableFrom(type) && !type.IsInterface)
                    .ToList();
                foreach (var guid in allGuids)
                {
                    c.MapType(guid, () => new OpenApiSchema { Type = "string", Format = "uuid" });
                }

            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "api-docs";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    c.DocExpansion(DocExpansion.List);
                    c.DisplayRequestDuration();
                });
            return app;
        }
    }
}
