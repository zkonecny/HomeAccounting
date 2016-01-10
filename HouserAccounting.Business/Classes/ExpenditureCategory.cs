using System.Collections.Generic;

namespace HouseAccounting.Business.Classes
{
    public class ExpenditureCategory : Category
    {
        public ICollection<Expenditure> Expenditures { get; set; }
    }
}