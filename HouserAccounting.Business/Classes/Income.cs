using System;

namespace HouserAccounting.Business.Classes
{
    public class Income : DomainEntity
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public Person Person { get; set; }
    }
}
