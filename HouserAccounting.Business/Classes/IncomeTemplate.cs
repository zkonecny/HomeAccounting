using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Business.Classes
{
    public class IncomeTemplate : DomainEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<IncomeTemplateItem> Items { get; set; }
    }
}
