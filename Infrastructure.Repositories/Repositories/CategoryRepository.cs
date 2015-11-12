using System;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbProvider dbProvider;

        public CategoryRepository(IDbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            var entities = dbProvider.GetAll<CategoryEntity>();

            foreach (var categoryEntity in entities)
            {
                var category = new Category
                {
                    Id = categoryEntity.Id,
                    Name = categoryEntity.Name,
                    Description = categoryEntity.Description
                };

                if (categoryEntity.Person != null)
                {
                    var personEntity = dbProvider.FindById<PersonEntity>(categoryEntity.Person.Id);

                    category.Person = new Person
                    {
                        Id = personEntity.Id,
                        FirstName = personEntity.FirstName,
                        LastName = personEntity.LastName
                    };
                }

                categories.Add(category);
            }

            return categories;
        }

        public Category FindById(int id)
        {
            var entity = dbProvider.FindById<CategoryEntity>(id);

            var category = new Category
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };

            return category;
        }

        public void Add(Category domainEntity)
        {
            CategoryEntity entity = new CategoryEntity
            {
                Name = domainEntity.Name,
                Description = domainEntity.Description
            };

            if (domainEntity.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(domainEntity.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Insert(entity);
        }

        public void Update(Category domainEntity)
        {
            var entity = dbProvider.FindById<CategoryEntity>(domainEntity.Id);
            entity.Name = domainEntity.Name;
            entity.Description = domainEntity.Description;

            if (domainEntity.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(domainEntity.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Update(entity);
        }

        public void Remove(Category domainEntity)
        {
            var entity = dbProvider.FindById<CategoryEntity>(domainEntity.Id);
            dbProvider.Delete(entity);
        }
    }
}