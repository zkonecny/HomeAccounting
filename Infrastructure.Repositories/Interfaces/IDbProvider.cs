using System;
using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Interfaces
{
    public interface IDbProvider
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity, new();

        IEnumerable<TEntity> GetAll<TEntity>(params DbRef<TEntity>[] includes) where TEntity : BaseEntity, new();

        TEntity FindById<TEntity>(int id) where TEntity : BaseEntity, new();

        TEntity FindById<TEntity>(int id, params DbRef<TEntity>[] includes) where TEntity : BaseEntity, new();

        void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        LiteCollection<TEntity> GetCollection<TEntity>(Type entityType)
            where TEntity : BaseEntity, new();
    }
}
