using System.Collections.Generic;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IExpenditureCategoryRepository
    {
        void Add(ExpenditureCategory category);
        Category FindById(int id);
        IEnumerable<ExpenditureCategory> GetAll();
        void Remove(Category category);
        void Update(Category category);
    }
}