using Questao5.Infrastructure.Repositories.Commands;
using Questao5.Infrastructure.Repositories.Queries;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAccountQueriesRepository, AccountQueriesRepository>();
            services.AddTransient<IAccountCommandsRepository, AccountCommandsRepository>();

            AddSqlLite(services, configuration);
            return services;
        }
        private static void AddSqlLite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new DatabaseConfig { Name = configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
            services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

        }
    }
}