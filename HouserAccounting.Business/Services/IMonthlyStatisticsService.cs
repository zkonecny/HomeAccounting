using System.Collections.Generic;
using HouseAccounting.Business.Classes;

namespace HouseAccounting.Business.Services
{
    public interface IMonthlyStatisticsService
    {
        IEnumerable<MonthlyItem> GetAllMonthlyStatistics();

        IEnumerable<MonthlyItem> GetMonthlyStatistics(int year, int month);
    }
}