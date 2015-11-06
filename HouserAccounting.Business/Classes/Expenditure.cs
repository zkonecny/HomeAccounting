using System;

namespace HouserAccounting.Business.Classes
{
    public class Expenditure : DomainEntity
    {
        public DateTime Created { get; set; }

        public int Amount { get; set; }

        public Category Category { get; set; }

        public Person User { get; set; }
    }
}
