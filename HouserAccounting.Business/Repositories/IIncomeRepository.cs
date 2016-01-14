using System.Collections.Generic;
using HouseAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IIncomeRepository
    {
        void Add(Income income);
        Income FindById(int id);
        IEnumerable<Income> FindByDate(int year, int month);
        IEnumerable<Income> GetAll();
        void Remove(Income income);
        void Update(Income income);
    }
}