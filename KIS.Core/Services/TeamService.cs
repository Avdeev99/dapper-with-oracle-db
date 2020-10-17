using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;
using KIS.Core.Repositories.Contracts;
using KIS.Core.Services.Contracts;

namespace KIS.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public Task<IEnumerable<TeamListModel>> GetAllWithTotalCost()
        {
            return teamRepository.GetAllWithTotalCost();
        }

        public async Task<TeamModel> Create(TeamModel team)
        {
            return await teamRepository.Create(team);
        }

        public async Task<long> GetTeamLastYearProfit(string teamName)
        {
            return await teamRepository.GetTeamLastYearProfit(teamName);
        }
    }
}
