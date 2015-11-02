using System;
using System.Collections.Generic;

namespace HouseAccounting.Model.Classes
{
    public class User : DomainEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
