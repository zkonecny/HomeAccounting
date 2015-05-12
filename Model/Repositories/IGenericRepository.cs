
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HouseAccounting.Model.Interfaces;
using HouseAccounting.Model.Specifications;

namespace HouseAccounting.Model.Repositories
{
    public interface IGenericRepository<TDomainEntity> 
        where TDomainEntity : IDomainEntity
    {
        TDomainEntity FindById(int id);

        TDomainEntity FindOne(ISpecification<TDomainEntity> spec);

        IEnumerable<TDomainEntity> Find(ISpecification<TDomainEntity> spec);

        void Add(TDomainEntity entity);

        void Remove(TDomainEntity entity);
    }
}
