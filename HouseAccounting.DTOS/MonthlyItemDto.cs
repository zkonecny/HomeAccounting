﻿namespace HouseAccounting.DTOS
{
    public class MonthlyItemDto
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int TotalIncomes { get; set; }

        public int TotalExpenditures { get; set; }

        public int Remainder { get { return TotalIncomes - TotalExpenditures; } }

        public PersonDto Person { get; set; }

        public CategoryDto Category { get; set; }
    }
}
