using HouseAccounting.Business.Classes;
using System.Collections.Generic;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IIncomeCategoryRepository 
    {
        void Add(IncomeCategory category);
        IncomeCategory FindById(int id);
        IEnumerable<IncomeCategory> GetAll();
        void Remove(IncomeCategory category);
        void Update(IncomeCategory category);
    }
}