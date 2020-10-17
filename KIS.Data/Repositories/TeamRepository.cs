using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using KIS.Core.Domain.Models;
using KIS.Core.Repositories.Contracts;
using KIS.Core.Services;

namespace KIS.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private const string ResourcePath = "Resources.Team";
        private static readonly Lazy<string> GetTeamsWithTotalCost = ScriptLoader.GetLazyEmbeddedResourceByPath<TeamRepository>(ResourcePath);
        private static readonly Lazy<string> GetTeamYearProfit = ScriptLoader.GetLazyEmbeddedResourceByPath<TeamRepository>(ResourcePath);

        private readonly IDbConnection dbConnection;

        public TeamRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TeamListModel>> GetAllWithTotalCost()
        {
            var commandDefinition = new CommandDefinition(GetTeamsWithTotalCost.Value);
            return await dbConnection.QueryAsync<TeamListModel>(commandDefinition);
        }

        public async Task<TeamModel> Create(TeamModel team)
        {
            var parameters = new DynamicParameters(new
            {
                T_LEAGUE_ID = team.LeagueId,
                T_NAME = team.Name,
                T_FOUNDATION_DATE = team.FoundationDate,
                T_DESCRIPTION = team.Description
            });

            await dbConnection.ExecuteAsync("INSERT_TEAM", parameters, null, null, CommandType.StoredProcedure);

            return team;
        }

        public async Task<long> GetTeamLastYearProfit(string teamName)
        {
            var parameters = new DynamicParameters(new
            {
                TeamName = teamName,
                StartDate = DateTime.UtcNow.AddYears(-1),
                EndDate = DateTime.UtcNow
            });

            var commandDefinition = new CommandDefinition(GetTeamYearProfit.Value, parameters);
            return await dbConnection.QueryFirstOrDefaultAsync<long>(commandDefinition);
        }
    }
}
