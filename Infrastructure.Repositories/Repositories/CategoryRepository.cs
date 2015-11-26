using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public abstract class CategoryRepository
    {
        private readonly IDbProvider dbProvider;
        private readonly IEntityTranslator translator;

        protected CategoryRepository(IDbProvider dbProvider, IEntityTranslator translator)
        {
            this.dbProvider = dbProvider;
            this.translator = translator;
        }

        protected void MapPerson(BaseCategoryEntity categoryEntity, Category category)
        {
            if (categoryEntity.Person != null)
            {
                var personEntity = dbProvider.FindById<PersonEntity>(categoryEntity.Person.Id);
                category.Person = translator.TranslateTo<Person>(personEntity);
            }
        }
    }
}