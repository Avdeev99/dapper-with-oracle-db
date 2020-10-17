using System.Collections.Generic;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;

namespace KIS.Core.Repositories.Contracts
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<PlayerModel>> GetByTeamId(long teamId);
    }
}
