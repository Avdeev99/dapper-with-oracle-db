using System;
using System.Collections.Generic;
using System.Text;

namespace KIS.Core.Domain.Models
{
    public class LeagueModel
    {
        public long LeagueId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }
    }
}
