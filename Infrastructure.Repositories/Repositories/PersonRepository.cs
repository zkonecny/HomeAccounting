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

            // TODO add catageries
            List<Person> persons = entities.Select(entity => new Person
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            }).ToList();

            return persons;
        }

        public Person FindById(int id)
        {
            var entity = dbProvider.FindById<PersonEntity>(id);

            var person = new Person
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

            return person;
        }

        public void Add(Person domainEntity)
        {
            PersonEntity entity = new PersonEntity
            {
                FirstName = domainEntity.FirstName,
                LastName = domainEntity.LastName
            };

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
            dbProvider.Delete<PersonEntity>(entity);
        }
    }
}