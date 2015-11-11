﻿using System;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories
{
    public class DbProvider : IDbProvider
    {
        private const string connectionString = @"C:\Temp\MyData.db";

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection<TEntity>(db, typeof(TEntity).Name);

                return collection.FindAll().ToList();
            }
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Action<TEntity>[] includes) where TEntity : BaseEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection<TEntity>(db, typeof(TEntity).Name);
                

                return collection.FindAll().ToList();
            }
        }

        public TEntity FindById<TEntity>(int id) where TEntity : BaseEntity, new()
        {
            return FindById<TEntity>(id, null);
        }

        public TEntity FindById<TEntity>(int id, Action<TEntity>[] includes) where TEntity : BaseEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection<TEntity>(db, typeof(TEntity).Name);

                AddIncludes(collection, includes);

                var result = collection.FindById(new BsonValue(id));

                return result;
            }
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection(db, entity);

                var result = collection.Insert(entity);
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection(db, entity);

                var result = collection.Update(entity);
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection(db, entity);

                var result = collection.Delete(new BsonValue(entity.Id));
            }
        }

        public LiteCollection<TEntity> GetCollection<TEntity>(Type entityType) where TEntity : BaseEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collectionName = entityType.Name;
                return GetCollection<TEntity>(db, collectionName);
            }
        }

        private LiteCollection<TEntity> GetCollection<TEntity>(LiteDatabase database, TEntity entity)
            where TEntity : BaseEntity, new()
        {
            var collectionName = entity.GetType().Name;
            return GetCollection<TEntity>(database, collectionName);
        }

        private LiteCollection<TEntity> GetCollection<TEntity>(LiteDatabase database, string collectionName)
            where TEntity : BaseEntity, new()
        {
            var collection = database.GetCollection<TEntity>(collectionName);
            return collection;
        }

        private void AddIncludes<TEntity>(LiteCollection<TEntity> collection, Action<TEntity>[] includes)
            where TEntity : BaseEntity, new()
        {
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    collection.Include(include);
                }
            }
        }
    }
}
