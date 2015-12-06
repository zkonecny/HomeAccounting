using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IDbProvider dbProvider;
        private readonly IEntityTranslator translator;

        protected BaseRepository(IDbProvider dbProvider, IEntityTranslator translator)
        {
            this.dbProvider = dbProvider;
            this.translator = translator;
        }

        protected Person MapPerson(DbRef<PersonEntity> personEntity)
        {
            if (personEntity != null)
            {
                var pe = dbProvider.FindById<PersonEntity>(personEntity.Id);
                return translator.TranslateTo<Person>(pe);
            }

            return null;
        }

        protected void UpdatePersonEntity(Person person, DbRef<PersonEntity> personEntity)
        {
            if (person != null)
            {
                var entity = dbProvider.FindById<PersonEntity>(person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                personEntity = new DbRef<PersonEntity>(persons, entity.Id);
            }
            else
            {
                personEntity = null;
            }
        }
    }
}