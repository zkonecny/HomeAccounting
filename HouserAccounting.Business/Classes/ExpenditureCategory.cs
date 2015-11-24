using System.Collections.Generic;

namespace HouserAccounting.Business.Classes
{
    public class ExpenditureCategory : Category
    {
        public ICollection<Expenditure> Expenditures { get; set; }
    }
}