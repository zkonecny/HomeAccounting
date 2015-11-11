using System.Collections.Generic;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Specifications;
using LiteDB;

namespace HouserAccounting.Business.Repositories
{
    public interface IGenericRepository<TDomainEntity> where TDomainEntity : DomainEntity, new()
    {
        IEnumerable<TDomainEntity> GetAll();

        TDomainEntity FindById(int id);

        void Add(TDomainEntity domainEntity);

        void Update(TDomainEntity domainEntity);

        void Remove(TDomainEntity domainEntity);
    }
}
