using System;
using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class IncomeRepository : BaseRepository, IIncomeRepository
    {
        private readonly IDbProvider dbProvider;
        private readonly IEntityTranslator translator;

        public IncomeRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
            this.dbProvider = dbProvider;
            this.translator = translator;
        }

        public IEnumerable<Income> GetAll()
        {
            List<Income> incomes = new List<Income>();

            var entities = dbProvider.GetAll<IncomeEntity>();

            foreach (var incomeEntity in entities)
            {
                var income = translator.TranslateTo<Income>(incomeEntity);

                income.Person = MapPerson(incomeEntity.Person);
                incomes.Add(income);
            }

            return incomes;
        }

        public Income FindById(int id)
        {
            var incomeEntity = dbProvider.FindById<IncomeEntity>(id);
            var income = translator.TranslateTo<Income>(incomeEntity);
            income.Person = MapPerson(incomeEntity.Person);

            return income;
        }

        public void Add(Income income)
        {
            var incomeEntity = translator.TranslateTo<IncomeEntity>(income);

            if (incomeEntity.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(income.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                incomeEntity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }

            dbProvider.Insert(incomeEntity);
        }

        public void Update(Income income)
        {
            var entity = dbProvider.FindById<IncomeEntity>(income.Id);
            entity.Amount = income.Amount;
            entity.Description = income.Description;
            entity.Modified = DateTime.Now;

            if (income.Person != null)
            {
                var person = dbProvider.FindById<PersonEntity>(income.Person.Id);
                var persons = dbProvider.GetCollection<PersonEntity>(typeof(PersonEntity));
                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
            }
            else
            {
                entity.Person = null;
            }

            if (income.Category != null)
            {
                var category = dbProvider.FindById<IncomeCategoryEntity>(income.Category.Id);
                var categories = dbProvider.GetCollection<IncomeCategoryEntity>(typeof(IncomeCategoryEntity));
                entity.Category = new DbRef<IncomeCategoryEntity>(categories, category.Id);
            }
            else
            {
                entity.Category = null;
            }

            dbProvider.Update(entity);
        }

        public void Remove(Income income)
        {
            var entity = dbProvider.FindById<IncomeEntity>(income.Id);
            dbProvider.Delete(entity);
        }
    }
}