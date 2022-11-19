namespace HouseAccounting.Business.Classes
{
    public class MonthlyItem
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int TotalIncomes { get; set; }

        public int TotalExpenditures { get; set; }

        public Person Person { get; set; }

        public Category Category { get; set; }
    }
}
