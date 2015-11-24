using System.Collections.Generic;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IIncomeCategoryRepository
    {
        void Add(IncomeCategory category);
        Category FindById(int id);
        IEnumerable<IncomeCategory> GetAll();
        void Remove(Category category);
        void Update(Category category);
    }
}