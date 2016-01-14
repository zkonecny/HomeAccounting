using System;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace HouseAccounting.Infrastructure.Repositories
{
    public class DbProvider : IDbProvider
    {
        private string connectionStringKey = @"HouseAccountingConnectionString";
        private string connectionString;

        public string ConnectionString
        {
            get
            {
                if (connectionString == null)
                {
                    connectionString = ConfigurationManager.AppSettings[connectionStringKey];
                }

                if (connectionString == null)
                {
                    throw new ArgumentNullException("connection string");
                }

                return connectionString;
            }
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity, new()
        {
            return GetAll<TEntity>(null);
        }

        public IEnumerable<TEntity> GetAll<TEntity>(params DbRef<TEntity>[] includes) where TEntity : BaseEntity, new()
        {
            using (var database = new LiteDatabase(ConnectionString))
            {
                var collection = GetCollection<TEntity>(database, typeof(TEntity).Name);

                AddIncludes(database, collection, includes);

                return collection.FindAll().ToList();
            }
        }

        public TEntity FindById<TEntity>(int id) where TEntity : BaseEntity, new()
        {
            return FindById<TEntity>(id, null);
        }

        public TEntity FindById<TEntity>(int id, params DbRef<TEntity>[] includes) where TEntity : BaseEntity, new()
        {
            using (var database = new LiteDatabase(ConnectionString))
            {
                var collection = GetCollection<TEntity>(database, typeof(TEntity).Name);

                AddIncludes(database, collection, includes);

                var result = collection.FindById(new BsonValue(id));

                return result;
            }
        }

        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate, int skip = 0, int limit = int.MaxValue)
            where TEntity : BaseEntity, new()
        {
            using (var database = new LiteDatabase(ConnectionString))
            {
                var collection = GetCollection<TEntity>(database, typeof(TEntity).Name);

                var result = collection.Find(predicate, skip, limit).ToList();

                return result;
            }
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            using (var database = new LiteDatabase(ConnectionString))
            {
                entity.Created = DateTime.Now;
                var collection = GetCollection(database, entity);
                var result = collection.Insert(entity);
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            using (var database = new LiteDatabase(ConnectionString))
            {
                entity.Modified = DateTime.Now;
                var collection = GetCollection(database, entity);
                var result = collection.Update(entity);
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            using (var database = new LiteDatabase(ConnectionString))
            {
                var collection = GetCollection(database, entity);
                var result = collection.Delete(new BsonValue(entity.Id));
            }
        }

        public LiteCollection<TEntity> GetCollection<TEntity>(Type entityType) where TEntity : BaseEntity, new()
        {
            using (var database = new LiteDatabase(ConnectionString))
            {
                var collectionName = entityType.Name;
                return GetCollection<TEntity>(database, collectionName);
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

        private void AddIncludes<TEntity>(LiteDatabase database, LiteCollection<TEntity> collection, DbRef<TEntity>[] includes)
            where TEntity : BaseEntity, new()
        {
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    collection.Include(x => include.Fetch(database));
                }
            }
        }
    }
}
