using HouseAccounting.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories
{
    public class DbProvider : IDbProvider
    {
        private const string connectionString = @"C:\Temp\MyData.db";

        public IEnumerable<TDomainEntity> GetAll<TDomainEntity>() where TDomainEntity : DomainEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection<TDomainEntity>(db, typeof(TDomainEntity).Name);

                return collection.FindAll().ToList();
            }
        }

        public TDomainEntity FindById<TDomainEntity>(int id) where TDomainEntity : DomainEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection<TDomainEntity>(db, typeof(TDomainEntity).Name);

                var result = collection.FindById(new BsonValue(id));

                return result;
            }
        }

        public void Insert<TDomainEntity>(TDomainEntity entity) where TDomainEntity : DomainEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection(db, entity);

                var result = collection.Insert(entity);
            }
        }

        public void Update<TDomainEntity>(TDomainEntity entity) where TDomainEntity : DomainEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection(db, entity);

                var result = collection.Update(entity);
            }
        }

        public void Delete<TDomainEntity>(TDomainEntity entity) where TDomainEntity : DomainEntity, new()
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var collection = GetCollection(db, entity);

                var result = collection.Delete(new BsonValue(entity.Id));
            }
        }

        private LiteCollection<TDomainEntity> GetCollection<TDomainEntity>(LiteDatabase database, TDomainEntity entity)
            where TDomainEntity : DomainEntity, new()
        {
            var collectionName = entity.GetType().Name;
            return GetCollection<TDomainEntity>(database, collectionName);
        }

        private LiteCollection<TDomainEntity> GetCollection<TDomainEntity>(LiteDatabase database, string collectionName)
            where TDomainEntity : DomainEntity, new()
        {
            var collection = database.GetCollection<TDomainEntity>(collectionName);
            return collection;
        }
    }
}
