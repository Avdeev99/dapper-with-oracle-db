using System.Data;
using KIS.Core.Repositories.Contracts;
using KIS.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace KIS.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(
            this IServiceCollection services,
            IConfiguration configuration,
            string dbConnectionStringName)
        {
            services.AddScoped<IDbConnection>(_ => new OracleConnection(configuration.GetConnectionString(dbConnectionStringName)));

            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();

            return services;
        }
    }
}
