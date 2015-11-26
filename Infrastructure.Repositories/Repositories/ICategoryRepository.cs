using System.Collections.Generic;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category FindById(int id);
        IEnumerable<Category> GetAll();
        void Remove(Category category);
        void Update(Category category);
    }
}