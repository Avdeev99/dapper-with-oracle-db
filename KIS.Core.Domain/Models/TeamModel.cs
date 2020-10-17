using System;

namespace KIS.Core.Domain.Models
{
    public class TeamModel
    {
        public long TeamId { get; set; }

        public long LeagueId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime FoundationDate { get; set; }
    }
}
