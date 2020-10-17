using System.Collections.Generic;
using System.Threading.Tasks;
using KIS.Core.Domain.Models;

namespace KIS.Core.Services.Contracts
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamListModel>> GetAllWithTotalCost();

        Task<TeamModel> Create(TeamModel team);

        Task<long> GetTeamLastYearProfit(string teamName);
    }
}
