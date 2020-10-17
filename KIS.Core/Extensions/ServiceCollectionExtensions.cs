using KIS.Core.Services;
using KIS.Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace KIS.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ILeagueService, LeagueService>();

            return services;
        }
    }
}
