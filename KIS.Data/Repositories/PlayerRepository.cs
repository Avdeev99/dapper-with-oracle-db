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
    public class PlayerRepository : IPlayerRepository
    {
        private const string ResourcePath = "Resources.Player";
        private static readonly Lazy<string> GetPlayersByTeamId = ScriptLoader.GetLazyEmbeddedResourceByPath<TeamRepository>(ResourcePath);

        private readonly IDbConnection dbConnection;

        public PlayerRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<IEnumerable<PlayerModel>> GetByTeamId(long teamId)
        {
            var parameters = new DynamicParameters(new
            {
                TeamId = teamId
            });
            var commandDefinition = new CommandDefinition(GetPlayersByTeamId.Value, parameters);
            return await dbConnection.QueryAsync<PlayerModel>(commandDefinition);
        }

        public async Task<PlayerModel> Create(PlayerModel player)
        {
            var parameters = new DynamicParameters(new
            {
                P_TEAM_ID = player.TeamId,
                P_FIRST_NAME = player.FirstName,
                P_LAST_NAME = player.LastName,
                P_DATE_OF_BIRTH = player.DateOfBirth,
                P_POSITION_CD = player.PositionCode,
                P_TRANSFER_COST = player.TransferCost
            });
            await dbConnection.ExecuteAsync("INSERT_PLAYER", CommandType.StoredProcedure);
            return player;
        }
    }
}
