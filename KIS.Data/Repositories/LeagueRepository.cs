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
    public class LeagueRepository : ILeagueRepository
    {
        private const string ResourcePath = "Resources.League";
        private static readonly Lazy<string> GetLeagues = ScriptLoader.GetLazyEmbeddedResourceByPath<TeamRepository>(ResourcePath);

        private readonly IDbConnection dbConnection;

        public LeagueRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<IEnumerable<LeagueModel>> GetAll()
        {
            var commandDefinition = new CommandDefinition(GetLeagues.Value);
            return await dbConnection.QueryAsync<LeagueModel>(commandDefinition);
        }
    }
}
