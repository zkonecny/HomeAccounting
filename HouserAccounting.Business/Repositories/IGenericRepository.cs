using System.Collections.Generic;
using HouseAccounting.Business.Classes;
using HouseAccounting.Business.Specifications;
using LiteDB;

namespace HouseAccounting.Business.Repositories
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
