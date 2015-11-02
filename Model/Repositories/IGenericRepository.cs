
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseAccounting.Model.Classes;
using HouseAccounting.Model.Specifications;

namespace HouseAccounting.Model.Repositories
{
    public interface IGenericRepository<TDomainEntity> where TDomainEntity : DomainEntity
    {
        IEnumerable<TDomainEntity> GetAll();

        TDomainEntity FindById(int id);

        TDomainEntity FindOne(ISpecification<TDomainEntity> spec);

        IEnumerable<TDomainEntity> Find(ISpecification<TDomainEntity> spec);

        void Add(TDomainEntity entity);

        void Update(TDomainEntity entity);

        void Remove(TDomainEntity entity);
    }
}
