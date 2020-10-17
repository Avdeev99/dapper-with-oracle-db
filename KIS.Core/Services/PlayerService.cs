using System.Collections.Generic;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;
using KIS.Core.Repositories.Contracts;
using KIS.Core.Services.Contracts;

namespace KIS.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task<IEnumerable<PlayerModel>> GetByTeamId(long teamId)
        {
            return await playerRepository.GetByTeamId(teamId);
        }
    }
}
