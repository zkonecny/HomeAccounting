using System;
using System.Collections.Generic;
using HouseAccounting.Model.Repositories;
using HouseAccounting.Model.Specifications;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Model.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class GenericRepository<TDomainEntity> : IGenericRepository<TDomainEntity>
        where TDomainEntity : DomainEntity, new()
    {
        private readonly IDbProvider dbProvider;

        public GenericRepository(IDbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        public IEnumerable<TDomainEntity> GetAll()
        {
            return dbProvider.GetAll<TDomainEntity>();
        }

        public TDomainEntity FindById(int id)
        {
            return dbProvider.FindById<TDomainEntity>(id);
        }

        public TDomainEntity FindOne(ISpecification<TDomainEntity> spec)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDomainEntity> Find(ISpecification<TDomainEntity> spec)
        {
            throw new NotImplementedException();
        }

        public void Add(TDomainEntity entity)
        {
            dbProvider.Insert(entity);
        }

        public void Update(TDomainEntity entity)
        {
            dbProvider.Update(entity);
        }

        public void Remove(TDomainEntity entity)
        {
            dbProvider.Delete(entity);
        }
    }
}
