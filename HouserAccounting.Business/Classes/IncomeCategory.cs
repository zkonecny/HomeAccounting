using System.Collections.Generic;

namespace HouserAccounting.Business.Classes
{
    public class IncomeCategory : Category
    {
        public ICollection<Income> Incomes { get; set; }
    }
}