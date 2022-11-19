using System.Collections.Generic;

namespace HouseAccounting.Business.Classes
{
    public class IncomeTemplate : DomainEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<IncomeTemplateItem> Items { get; set; }
    }
}
