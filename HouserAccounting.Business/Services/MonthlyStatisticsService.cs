using HouseAccounting.Business.Classes;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Business.Services
{
    public class MonthlyStatisticsService : IMonthlyStatisticsService
    {
        private readonly IIncomeRepository incomeRepository;
        private readonly IExpenditureRepository expenditureRepository;

        public MonthlyStatisticsService(IIncomeRepository incomeRepository, IExpenditureRepository expenditureRepository)
        {
            this.incomeRepository = incomeRepository;
            this.expenditureRepository = expenditureRepository;
        }

        public IEnumerable<MonthlyItem> GetMonthlyStatistic()
        {
            var monthlyItems = new Dictionary<string, MonthlyItem>();
            var allIncomes = incomeRepository.GetAll().OrderByDescending(income => income.Created);
            var allExpenditures = expenditureRepository.GetAll().OrderByDescending(expenditure => expenditure.Created);

            AddIncomes(monthlyItems, allIncomes);
            AddExpenditures(monthlyItems, allExpenditures);

            return monthlyItems.Select(pair => pair.Value);
        }

        private void AddIncomes(IDictionary<string, MonthlyItem> monthlyItems, IEnumerable<Income> incomes)
        {
            foreach (var income in incomes)
            {
                var key = GetKey(income.Created);
                if (monthlyItems.ContainsKey(key))
                {
                    monthlyItems[key].TotalIncomes += income.Amount;
                }
                else
                {
                    monthlyItems[key] = new MonthlyItem()
                    {
                        Year = income.Created.Year,
                        Month = income.Created.Month,
                        TotalIncomes = income.Amount
                    };
                }
            }
        }

        private void AddExpenditures(IDictionary<string, MonthlyItem> monthlyItems, IEnumerable<Expenditure> expenditures)
        {
            foreach (var expenditure in expenditures)
            {
                var key = GetKey(expenditure.Created);
                if (monthlyItems.ContainsKey(key))
                {
                    monthlyItems[key].TotalExpenditures += expenditure.Amount;
                }
                else
                {
                    monthlyItems[key] = new MonthlyItem()
                    {
                        Year = expenditure.Created.Year,
                        Month = expenditure.Created.Month,
                        TotalExpenditures = expenditure.Amount
                    };
                }
            }
        }

        private string GetKey(DateTime createdDate)
        {
            return createdDate.Year.ToString() + createdDate.Month;
        }
    }
}
