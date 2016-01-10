using System.Collections.Generic;
using HouseAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IPersonRepository
    {
        void Add(Person entity);
        Person FindById(int id);
        IEnumerable<Person> GetAll();
        void Remove(Person entity);
        void Update(Person entity);
    }
}