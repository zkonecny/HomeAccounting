using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.DTOS
{
    public class MonthlyItemDto
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int TotalIncomes { get; set; }

        public string TotalIncomesInCurrency { get { return TotalIncomes.ToCurrencyString(); } }

        public int TotalExpenditures { get; set; }

        public string TotalExpendituresInCurrency { get { return TotalExpenditures.ToCurrencyString(); } }

        public int Remainder { get { return TotalIncomes - TotalExpenditures; } }

        public string RemainderInCurrency { get { return Remainder.ToCurrencyString(); } }
    }
}
