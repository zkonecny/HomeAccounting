using HouseAccounting.Business.Classes;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<MonthlyItem> GetAllMonthlyStatistics()
        {
            var monthlyItems = new Dictionary<string, MonthlyItem>();
            var allIncomes = incomeRepository.GetAll().OrderByDescending(income => income.Created);
            var allExpenditures = expenditureRepository.GetAll().OrderByDescending(expenditure => expenditure.Created);

            AddIncomes(monthlyItems, allIncomes);
            AddExpenditures(monthlyItems, allExpenditures);

            return monthlyItems.Select(pair => pair.Value);
        }

        private void AddIncomes(IDictionary<string, MonthlyItem> monthlyItems, IEnumerable<Income> incomes, bool useCategoryAndPerson = false)
        {
            foreach (var income in incomes)
            {
                string key = null;
                if (useCategoryAndPerson)
                {
                    key = GetMonthlyKey(income.Created, income.Category, income.Person);
                }
                else
                {
                    key = GetKey(income.Created);
                }

                if (monthlyItems.ContainsKey(key))
                {
                    if (monthlyItems[key] != null)
                    {
                        monthlyItems[key].TotalIncomes += income.Amount;
                    }
                    else
                    {
                        monthlyItems[key] = new MonthlyItem { TotalIncomes = income.Amount };
                    }
                }
                else
                {
                    monthlyItems[key] = new MonthlyItem()
                    {
                        Year = income.Created.Year,
                        Month = income.Created.Month,
                        TotalIncomes = income.Amount,
                        Category = income.Category,
                        Person = income.Person
                    };
                }
            }
        }

        private void AddExpenditures(IDictionary<string, MonthlyItem> monthlyItems, IEnumerable<Expenditure> expenditures,
           bool useCategoryAndPerson = false)
        {
            foreach (var expenditure in expenditures)
            {
                string key = null;
                if (useCategoryAndPerson)
                {
                    key = GetMonthlyKey(expenditure.Created, expenditure.Category, expenditure.Person);
                }
                else
                {
                    key = GetKey(expenditure.Created);
                }

                if (monthlyItems.ContainsKey(key))
                {
                    if (monthlyItems[key] != null)
                    {
                        monthlyItems[key].TotalExpenditures += expenditure.Amount;
                    }
                    else
                    {
                        monthlyItems[key] = new MonthlyItem { TotalExpenditures = expenditure.Amount };
                    }
                }
                else
                {
                    monthlyItems[key] = new MonthlyItem()
                    {
                        Year = expenditure.Created.Year,
                        Month = expenditure.Created.Month,
                        TotalExpenditures = expenditure.Amount,
                        Category = expenditure.Category,
                        Person = expenditure.Person
                    };
                }
            }
        }

        private string GetMonthlyKey(DateTime createdDate, Category category, Person person)
        {
            var key = GetKey(createdDate);

            if (category != null)
            {
                key += category.Id;
                key += category.Created.Ticks.ToString();
            }

            if (person != null)
            {
                key += person.Id;
                key += person.Created.Ticks.ToString();
            }

            return key;
        }

        private string GetKey(DateTime createdDate)
        {
            return createdDate.Year.ToString() + createdDate.Month;
        }

        public MonthlyData GetMonthlyStatistics(int year, int month)
        {
            var monthlyData = new MonthlyData();
            var monthlyItems = new Dictionary<string, MonthlyItem>();
            var allIncomes = incomeRepository.FindByDate(year, month).OrderByDescending(expenditure => expenditure.Created);
            var allExpenditures = expenditureRepository.FindByDate(year, month).OrderByDescending(expenditure => expenditure.Created);

            monthlyData.TotalIncomes = allIncomes.Sum(income => income.Amount);
            monthlyData.TotalExpenditures = allExpenditures.Sum(expenditure => expenditure.Amount);

            AddIncomes(monthlyItems, allIncomes, useCategoryAndPerson: true);
            AddExpenditures(monthlyItems, allExpenditures, useCategoryAndPerson: true);

            monthlyData.MonthlyItems = monthlyItems.Select(pair => pair.Value);

            return monthlyData;
        }
    }
}
