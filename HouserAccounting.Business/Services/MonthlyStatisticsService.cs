using HouseAccounting.Business.Classes;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Business.Services
{
    public class MonthlyStatisticsService
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
            var allIncomes = incomeRepository.GetAll().OrderByDescending(income => income.Created);
            var allExpenditures = expenditureRepository.GetAll().OrderByDescending(expenditure => expenditure.Created);

            return null;

        }
    }
}
