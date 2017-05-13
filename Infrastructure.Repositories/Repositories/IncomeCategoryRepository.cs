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
    public class IncomeCategoryRepository : BaseRepository, IIncomeCategoryRepository
    {
        public IncomeCategoryRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
        }

        public IEnumerable<IncomeCategory> GetAll()
        {
            List<IncomeCategory> categories = new List<IncomeCategory>();

            var entities = dbProvider.GetAll<IncomeCategoryEntity>();

            foreach (var categoryEntity in entities)
            {
                var category = translator.TranslateTo<IncomeCategory>(categoryEntity);
                category.Person = MapPerson(categoryEntity.Person);
                categories.Add(category);
            }

            return categories;
        }

        public IncomeCategory FindById(int id)
        {
            var categoryEntity = dbProvider.FindById<IncomeCategoryEntity>(id);
            var category = translator.TranslateTo<IncomeCategory>(categoryEntity);
            category.Person = MapPerson(categoryEntity.Person);

            return category;
        }

        public void Add(IncomeCategory category)
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

        public void Update(IncomeCategory category)
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

        public void Remove(IncomeCategory category)
        {
            var entity = dbProvider.FindById<IncomeCategoryEntity>(category.Id);
            dbProvider.Delete(entity);
        }
    }
}