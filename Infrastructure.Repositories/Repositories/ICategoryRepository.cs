using System.Collections.Generic;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category domainEntity);
        Category FindById(int id);
        IEnumerable<Category> GetAll();
        void Remove(Category domainEntity);
        void Update(Category domainEntity);
    }
}