using System.Collections.Generic;
using HouseAccounting.Business.Classes;

namespace HouseAccounting.Business.Services
{
    public interface IMonthlyStatisticsService
    {
        IEnumerable<MonthlyItem> GetAllMonthlyStatistics();

        MonthlyData GetMonthlyStatistics(int year, int month);
    }
}