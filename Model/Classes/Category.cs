using System.Collections.Generic;

namespace HouseAccounting.Model.Classes
{
    public class Category : DomainEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Person Person { get; set; }

        public ICollection<Expenditure> Expenditures { get; set; }

        public ICollection<Income> Incomes { get; set; }
    }
}
