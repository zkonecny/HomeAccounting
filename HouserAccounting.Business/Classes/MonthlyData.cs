using System.Collections.Generic;

namespace HouseAccounting.Business.Classes
{
    public class MonthlyData
    {
        public IEnumerable<MonthlyItem> MonthlyItems { get; set; }

        public int TotalIncomes { get; set; }

        public int TotalExpenditures { get; set; }
    }
}
