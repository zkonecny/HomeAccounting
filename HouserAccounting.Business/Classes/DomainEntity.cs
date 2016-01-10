using System;

namespace HouseAccounting.Business.Classes
{
    public class DomainEntity
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
