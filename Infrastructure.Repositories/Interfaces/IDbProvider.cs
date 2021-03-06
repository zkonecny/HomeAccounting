﻿using System;
using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Business.Classes;
using LiteDB;
using System.Linq.Expressions;

namespace HouseAccounting.Infrastructure.Repositories.Interfaces
{
    public interface IDbProvider
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity, new();

        IEnumerable<TEntity> GetAll<TEntity>(params TEntity[] includes) where TEntity : BaseEntity, new();

        TEntity FindById<TEntity>(int id) where TEntity : BaseEntity, new();

        TEntity FindById<TEntity>(int id, params TEntity[] includes) where TEntity : BaseEntity, new();

        IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate, int skip = 0, int limit = int.MaxValue)
            where TEntity : BaseEntity, new();

        void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity, new();

        LiteCollection<TEntity> GetCollection<TEntity>(Type entityType)
            where TEntity : BaseEntity, new();
    }
}
