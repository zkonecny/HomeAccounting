using System.Collections.Generic;
using HouseAccounting.Business.Classes;
using System.Linq.Expressions;
using System;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IExpenditureRepository
    {
        void Add(Expenditure expenditure);
        Expenditure FindById(int id);
        IEnumerable<Expenditure> Find<Expenditure>(Expression<Func<Expenditure, bool>> predicate, int skip = 0, int limit = int.MaxValue);
        IEnumerable<Expenditure> FindByDate(int year, int month);
        IEnumerable<Expenditure> GetAll();
        void Remove(Expenditure expenditure);
        void Update(Expenditure expenditure);
    }
}