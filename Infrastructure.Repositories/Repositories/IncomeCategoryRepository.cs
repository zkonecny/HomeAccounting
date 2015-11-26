using System;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class IncomeCategoryRepository : CategoryRepository, IIncomeCategoryRepository
    {
        private readonly IDbProvider dbProvider;
        private readonly IEntityTranslator translator;

        public IncomeCategoryRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
            this.dbProvider = dbProvider;
            this.translator = translator;
        }

        public IEnumerable<Category> GetAll()
        {
            List<IncomeCategory> categories = new List<IncomeCategory>();

            var entities = dbProvider.GetAll<IncomeCategoryEntity>();

            foreach (var categoryEntity in entities)
            {
                var category = translator.TranslateTo<IncomeCategory>(categoryEntity);

                MapPerson(categoryEntity, category);
                categories.Add(category);
            }

            return categories;
        }

        public Category FindById(int id)
        {
            var categoryEntity = dbProvider.FindById<IncomeCategoryEntity>(id);
            var category = translator.TranslateTo<Category>(categoryEntity);
            MapPerson(categoryEntity, category);

            return category;
        }

        public void Add(Category category)
        {
            var categoryEntity = translator.TranslateTo<IncomeCategoryEntity>(category);

            if (category.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(category.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                categoryEntity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Insert(categoryEntity);
        }

        public void Update(Category category)
        {
            var entity = dbProvider.FindById<IncomeCategoryEntity>(category.Id);
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

        public void Remove(Category category)
        {
            var entity = dbProvider.FindById<IncomeCategoryEntity>(category.Id);
            dbProvider.Delete(entity);
        }
    }
}