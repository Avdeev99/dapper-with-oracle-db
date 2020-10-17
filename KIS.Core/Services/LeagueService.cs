using System.Collections.Generic;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;
using KIS.Core.Repositories.Contracts;
using KIS.Core.Services.Contracts;

namespace KIS.Core.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository leagueRepository;

        public LeagueService(ILeagueRepository leagueRepository)
        {
            this.leagueRepository = leagueRepository;
        }

        public async Task<IEnumerable<LeagueModel>> GetAll()
        {
            return await leagueRepository.GetAll();
        }
    }
}
