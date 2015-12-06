using System;
using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class ExpenditureRepository : BaseRepository, IExpenditureRepository
    {
        private readonly IDbProvider dbProvider;
        private readonly IEntityTranslator translator;

        public ExpenditureRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
            this.dbProvider = dbProvider;
            this.translator = translator;
        }

        public IEnumerable<Expenditure> GetAll()
        {
            List<Expenditure> expenditures = new List<Expenditure>();

            var entities = dbProvider.GetAll<ExpenditureEntity>();

            foreach (var expenditureEntity in entities)
            {
                var expenditure = translator.TranslateTo<Expenditure>(expenditureEntity);

                expenditure.Person = MapPerson(expenditureEntity.Person);
                expenditure.Category = MapCategory(expenditureEntity.Category);
                expenditures.Add(expenditure);
            }

            return expenditures;
        }

        protected ExpenditureCategory MapCategory(DbRef<ExpenditureCategoryEntity> categoryEntity)
        {
            if (categoryEntity != null)
            {
                var ce = dbProvider.FindById<ExpenditureCategoryEntity>(categoryEntity.Id);
                return translator.TranslateTo<ExpenditureCategory>(ce);
            }

            return null;
        }

        public Expenditure FindById(int id)
        {
            var expenditureEntity = dbProvider.FindById<ExpenditureEntity>(id);
            var expenditure = translator.TranslateTo<Expenditure>(expenditureEntity);
            expenditure.Person = MapPerson(expenditureEntity.Person);
            expenditure.Category = MapCategory(expenditureEntity.Category);
            return expenditure;
        }

        public void Add(Expenditure expenditure)
        {
            var expenditureEntity = translator.TranslateTo<ExpenditureEntity>(expenditure);
            UpdatePersonEntity(expenditure.Person, expenditureEntity.Person);
            UpdateCategory(expenditure.Category, expenditureEntity.Category);
            dbProvider.Insert(expenditureEntity);
        }

        public void Update(Expenditure expenditure)
        {
            var expenditureEntity = dbProvider.FindById<ExpenditureEntity>(expenditure.Id);
            expenditureEntity.Amount = expenditure.Amount;
            expenditureEntity.Description = expenditure.Description;
            expenditureEntity.Modified = expenditure.Modified;

            UpdatePersonEntity(expenditure.Person, expenditureEntity.Person);
            UpdateCategory(expenditure.Category, expenditureEntity.Category);

            dbProvider.Update(expenditureEntity);
        }

        public void Remove(Expenditure expenditure)
        {
            var entity = dbProvider.FindById<ExpenditureEntity>(expenditure.Id);
            dbProvider.Delete(entity);
        }

        private void UpdateCategory(Category category, DbRef<ExpenditureCategoryEntity> categoryEntity)
        {
            if (category != null)
            {
                var entity = dbProvider.FindById<ExpenditureCategoryEntity>(category.Id);
                var categories = dbProvider.GetCollection<ExpenditureCategoryEntity>(typeof(ExpenditureCategoryEntity));
                categoryEntity = new DbRef<ExpenditureCategoryEntity>(categories, entity.Id);
            }
            else
            {
                categoryEntity = null;
            }
        }
    }
}