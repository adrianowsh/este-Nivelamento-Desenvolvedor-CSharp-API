using System.Reflection;
using MediatR;
using Microsoft.OpenApi.Models;
using Questao5.Application.Handlers;

namespace Questao5.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IConsultHandler, ConsultHandler>();
            services.AddTransient<IMovimentHandler, MovimentHandler>();
            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Questao 5 - Conta Bancaria.Api",
                    Version = "v1"
                });
            });
            return services;
        }
    }
}