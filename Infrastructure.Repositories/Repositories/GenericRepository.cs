using System;
using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;
using HouserAccounting.Business.Specifications;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class GenericRepository<TDomainEntity> : IGenericRepository<TDomainEntity> where TDomainEntity : DomainEntity, new()
    {
        public virtual IEnumerable<TDomainEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual TDomainEntity FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Add(TDomainEntity domainEntity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(TDomainEntity domainEntity)
        {
            throw new System.NotImplementedException();
        }

        public virtual  void Remove(TDomainEntity domainEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
