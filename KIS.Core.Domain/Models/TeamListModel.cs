using System;

namespace KIS.Core.Domain.Models
{
    public class TeamListModel
    {
        public long TeamId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public DateTime FoundationDate { get; set; }

        public float TotalCost { get; set; }
    }
}
