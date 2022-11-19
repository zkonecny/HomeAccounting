using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class ExpenditureCategoryRepository : BaseRepository, IExpenditureCategoryRepository
    {
        public ExpenditureCategoryRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
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
                categoryEntity.Person = person;
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
                entity.Person = person;
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