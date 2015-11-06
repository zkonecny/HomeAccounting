using System.Collections.Generic;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Specifications;

namespace HouserAccounting.Business.Repositories
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
