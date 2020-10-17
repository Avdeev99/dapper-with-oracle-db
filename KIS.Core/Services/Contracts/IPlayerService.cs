using System.Collections.Generic;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;

namespace KIS.Core.Services.Contracts
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerModel>> GetByTeamId(long teamId);
    }
}
