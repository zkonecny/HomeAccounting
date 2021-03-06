﻿namespace HouseAccounting.Business.Classes
{
    public abstract class Category : DomainEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Person Person { get; set; }
    }
}
