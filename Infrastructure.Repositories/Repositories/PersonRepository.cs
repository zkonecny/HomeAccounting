using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbProvider dbProvider;

        public PersonRepository(IDbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        public IEnumerable<Person> GetAll()
        {
            var entities = dbProvider.GetAll<PersonEntity>();

            return entities.Select(Mapper.Map).ToList();
        }

        public Person FindById(int id)
        {
            var entity = dbProvider.FindById<PersonEntity>(id);
            return Mapper.Map(entity);
        }

        public void Add(Person domainEntity)
        {
            PersonEntity entity = Mapper.Map(domainEntity);
            dbProvider.Insert(entity);
        }

        public void Update(Person domainEntity)
        {
            var entity = dbProvider.FindById<PersonEntity>(domainEntity.Id);
            entity.FirstName = domainEntity.FirstName;
            entity.LastName = domainEntity.LastName;

            dbProvider.Update(entity);
        }

        public void Remove(Person domainEntity)
        {
            var entity = dbProvider.FindById<PersonEntity>(domainEntity.Id);
            dbProvider.Delete(entity);
        }
    }
}