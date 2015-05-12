using System;
using HouseAccounting.Model.Interfaces;

namespace HouseAccounting.Model.Classes
{
    public class User : IDomainEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BornOn { get; set; }

        public Household Household { get; set; }
    }
}
