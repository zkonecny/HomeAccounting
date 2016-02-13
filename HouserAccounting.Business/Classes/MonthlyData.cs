using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Business.Classes
{
    public class MonthlyData
    {
        public IEnumerable<MonthlyItem> MonthlyItems { get; set; }

        public int TotalIncomes { get; set; }

        public int TotalExpenditures { get; set; }
    }
}
