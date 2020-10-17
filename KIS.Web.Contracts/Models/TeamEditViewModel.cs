using System.Collections.Generic;
using KIS.Core.Domain.Models;

namespace KIS.Web.Contracts.Models
{
    public class TeamEditViewModel
    {
        public TeamModel Team { get; set; }

        public List<LeagueModel> Leagues { get; set; }
    }
}
