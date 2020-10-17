using System.Collections.Generic;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;

namespace KIS.Core.Services.Contracts
{
    public interface ILeagueService
    {
        Task<IEnumerable<LeagueModel>> GetAll();
    }
}
