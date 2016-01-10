using System;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class ExpenditureCategoryRepository : BaseRepository, IExpenditureCategoryRepository
    {
        private readonly IDbProvider dbProvider;
        private readonly IEntityTranslator translator;

        public ExpenditureCategoryRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
            this.dbProvider = dbProvider;
            this.translator = translator;
        }

        public IEnumerable<ExpenditureCategory> GetAll()
        {
            List<ExpenditureCategory> categories = new List<ExpenditureCategory>();

            var entities = dbProvider.GetAll<ExpenditureCategoryEntity>();

            foreach (var categoryEntity in entities)
            {
                var category = translator.TranslateTo<ExpenditureCategory>(categoryEntity);

                category.Person = MapPerson(categoryEntity.Person);
                categories.Add(category);
            }

            return categories;
        }

        public ExpenditureCategory FindById(int id)
        {
            var categoryEntity = dbProvider.FindById<ExpenditureCategoryEntity>(id);
            var category = translator.TranslateTo<ExpenditureCategory>(categoryEntity);
            category.Person = MapPerson(categoryEntity.Person);
            
            return category;
        }

        public void Add(ExpenditureCategory category)
        {
            var categoryEntity = translator.TranslateTo<ExpenditureCategoryEntity>(category);

            if (category.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(category.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                categoryEntity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Insert(categoryEntity);
        }

        public void Update(ExpenditureCategory category)
        {
            var entity = dbProvider.FindById<ExpenditureCategoryEntity>(category.Id);
            entity.Name = category.Name;
            entity.Description = category.Description;

            if (category.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(category.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }
            else
            {
                entity.Person = null;
            }

            dbProvider.Update(entity);
        }

        public void Remove(ExpenditureCategory category)
        {
            var entity = dbProvider.FindById<ExpenditureCategoryEntity>(category.Id);
            dbProvider.Delete(entity);
        }
    }
}