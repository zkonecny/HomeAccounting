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
                expenditures.Add(expenditure);
            }

            return expenditures;
        }

        public Expenditure FindById(int id)
        {
            var expenditureEntity = dbProvider.FindById<ExpenditureEntity>(id);
            var expenditure = translator.TranslateTo<Expenditure>(expenditureEntity);
            expenditure.Person = MapPerson(expenditureEntity.Person);

            return expenditure;
        }

        public void Add(Expenditure expenditure)
        {
            var expenditureEntity = translator.TranslateTo<ExpenditureEntity>(expenditure);

            if (expenditureEntity.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(expenditure.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                expenditureEntity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Insert(expenditureEntity);
        }

        public void Update(Expenditure expenditure)
        {
            var entity = dbProvider.FindById<ExpenditureEntity>(expenditure.Id);
            entity.Amount = expenditure.Amount;
            entity.Description = expenditure.Description;
            entity.Modified = DateTime.Now;

            if (expenditure.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(expenditure.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }
            else
            {
                entity.Person = null;
            }

            if (expenditure.Category != null)
            {
                var category = dbProvider.FindById<ExpenditureCategoryEntity>(expenditure.Category.Id);
                var categories = dbProvider.GetCollection<ExpenditureCategoryEntity>(typeof(ExpenditureCategoryEntity));
                entity.Category = new DbRef<ExpenditureCategoryEntity>(categories, category.Id);
            }
            else
            {
                entity.Category = null;
            }

            dbProvider.Update(entity);
        }

        public void Remove(Expenditure expenditure)
        {
            var entity = dbProvider.FindById<ExpenditureEntity>(expenditure.Id);
            dbProvider.Delete(entity);
        }
    }
}