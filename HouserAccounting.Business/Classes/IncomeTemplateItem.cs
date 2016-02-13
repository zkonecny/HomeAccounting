using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Business.Classes
{
    public class IncomeTemplateItem : DomainEntity
    {
            public int Amount { get; set; }

        public string Description { get; set; }

        public IncomeCategory Category { get; set; }

        public Person Person { get; set; }
    }
}
