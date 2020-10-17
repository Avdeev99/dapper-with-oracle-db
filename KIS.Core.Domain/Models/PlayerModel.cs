using System;

namespace KIS.Core.Domain.Models
{
    public class PlayerModel
    {
        public long PlayerId { get; set; }

        public long TeamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PositionCode { get; set; }

        public decimal TransferCost { get; set; }
    }
}
