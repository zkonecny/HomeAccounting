using System.Collections.Generic;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IExpenditureRepository
    {
        void Add(Expenditure expenditure);
        Expenditure FindById(int id);
        IEnumerable<Expenditure> GetAll();
        void Remove(Expenditure expenditure);
        void Update(Expenditure expenditure);
    }
}