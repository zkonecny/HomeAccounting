using System.Collections.Generic;

namespace HouseAccounting.Business.Classes
{
    public class IncomeCategory : Category
    {
        public ICollection<Income> Incomes { get; set; }
    }
}