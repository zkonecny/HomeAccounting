using HouserAccounting.Business.Classes;
using System.Collections.Generic;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IExpenditureCategoryRepository 
    {
        void Add(ExpenditureCategory category);
        ExpenditureCategory FindById(int id);
        IEnumerable<ExpenditureCategory> GetAll();
        void Remove(ExpenditureCategory category);
        void Update(ExpenditureCategory category);
    }
}