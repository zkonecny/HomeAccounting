using System.Collections.Generic;

namespace HouserAccounting.Business.Classes
{
    public class Person : DomainEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
