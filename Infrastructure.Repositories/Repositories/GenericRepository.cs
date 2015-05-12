using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using HouseAccounting.Infrastructure.Repositories.DataClasses;
using HouseAccounting.Model.Interfaces;
using HouseAccounting.Model.Repositories;
using HouseAccounting.Model.Specifications;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class GenericRepository<TDomainEntity, TDataEntity> : IGenericRepository<TDomainEntity> 
        where TDomainEntity : IDomainEntity
        where TDataEntity : DataEntity
    {
        protected HouseAccountingDbContext _dbContext;
        protected DbSet<TDataEntity> _dbSet;

        public GenericRepository(HouseAccountingDbContext context)
        {
            this._dbContext = context;
            this._dbSet = this._dbContext.Set<TDataEntity>();
        }

        public TDomainEntity FindById(int id)
        {
            var dbEntity = this._dbSet.FirstOrDefault(d => d.Id == id);
            if (dbEntity != null)
            {
                //return null;
            }

            return default(TDomainEntity);
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
            throw new NotImplementedException();
        }

        public void Remove(TDomainEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
