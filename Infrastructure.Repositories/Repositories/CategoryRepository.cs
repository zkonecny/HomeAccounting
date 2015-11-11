using System.Collections.Generic;
using System.Linq;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IDbProvider dbProvider;

        public CategoryRepository(IDbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        public override IEnumerable<Category> GetAll()
        {
            var entities = dbProvider.GetAll<CategoryEntity>();

            // TODO add catageries
            List<Category> categories = entities.Select(entity => new Category
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            }).ToList();

            return categories;
        }

        public override Category FindById(int id)
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

        public override void Add(Category domainEntity)
        {
            CategoryEntity entity = new CategoryEntity
            {
                Name = domainEntity.Name,
                Description = domainEntity.Description
            };

            if (domainEntity.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(domainEntity.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof (PersonEntity));
                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Insert(entity);
        }

        public override void Update(Category domainEntity)
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

        public override void Remove(Category domainEntity)
        {
            var entity = dbProvider.FindById<CategoryEntity>(domainEntity.Id);
            dbProvider.Delete<CategoryEntity>(entity);
        }
    }
}