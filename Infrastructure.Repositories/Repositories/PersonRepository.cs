using System;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbProvider dbProvider;
        private readonly IEntityTranslator translator;

        public PersonRepository(IDbProvider dbProvider, IEntityTranslator translator)
        {
            this.dbProvider = dbProvider;
            this.translator = translator;
        }

        public IEnumerable<Person> GetAll()
        {
            var entities = dbProvider.GetAll<PersonEntity>();

            return entities.Select(personEntity => translator.TranslateTo<Person>(personEntity)).ToList();
        }

        public Person FindById(int id)
        {
            var entity = dbProvider.FindById<PersonEntity>(id);
            return translator.TranslateTo<Person>(entity);
        }

        public void Add(Person domainEntity)
        {
            PersonEntity entity = translator.TranslateTo<PersonEntity>(domainEntity);
            dbProvider.Insert(entity);
        }

        public void Update(Person domainEntity)
        {
            var entity = dbProvider.FindById<PersonEntity>(domainEntity.Id);
            entity.FirstName = domainEntity.FirstName;
            entity.LastName = domainEntity.LastName;
            entity.Modified = DateTime.Now;

            dbProvider.Update(entity);
        }

        public void Remove(Person domainEntity)
        {
            var entity = dbProvider.FindById<PersonEntity>(domainEntity.Id);
            dbProvider.Delete(entity);
        }
    }
}