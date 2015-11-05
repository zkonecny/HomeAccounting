using System;

namespace HouseAccounting.Model.Classes
{
    public class Income : DomainEntity
    {
        public DateTime Created { get; set; }

        public int Amount { get; set; }

       public Category Category { get; set; }

        public Person User { get; set; }
    }
}
