using System;
using LiteDB;

namespace HouserAccounting.Business.Classes
{
    public class Income : DomainEntity
    {
        public DateTime Created { get; set; }

        public int Amount { get; set; }

       public DbRef<Category> Category { get; set; }

        public DbRef<Person> Person { get; set; }
    }
}
