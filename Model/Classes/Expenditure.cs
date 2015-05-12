using System;
using HouseAccounting.Model.Interfaces;

namespace HouseAccounting.Model.Classes
{
    public class Expenditure : IDomainEntity
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public double Amount { get; set; }

        public Category Category { get; set; }

        public User User { get; set; }
    }
}
