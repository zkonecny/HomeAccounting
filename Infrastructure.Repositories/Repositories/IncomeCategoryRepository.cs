using System;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class IncomeCategoryRepository : IIncomeCategoryRepository
    {
        private readonly IDbProvider dbProvider;

        public IncomeCategoryRepository(IDbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        public IEnumerable<IncomeCategory> GetAll()
        {
            List<IncomeCategory> categories = new List<IncomeCategory>();

            var entities = dbProvider.GetAll<IncomeCategoryEntity>();

            foreach (var categoryEntity in entities)
            {
                var category = Mapper.Map(categoryEntity);

                if (categoryEntity.Person != null)
                {
                    var personEntity = dbProvider.FindById<PersonEntity>(categoryEntity.Person.Id);
                    category.Person = Mapper.Map(personEntity);
                }

                categories.Add(category);
            }

            return categories;
        }

        public Category FindById(int id)
        {
            var entity = dbProvider.FindById<IncomeCategoryEntity>(id);

            return Mapper.Map(entity);
        }

        public void Add(IncomeCategory category)
        {
            var entity = Mapper.Map(category);

            if (category.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(category.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Insert(entity);
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

            dbProvider.Update(entity);
        }

        public void Remove(Category category)
        {
            var entity = dbProvider.FindById<IncomeCategoryEntity>(category.Id);
            dbProvider.Delete(entity);
        }
    }
}