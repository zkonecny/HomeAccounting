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
                income.Category = MapCategory(incomeEntity.Category);
                incomes.Add(income);
            }

            return incomes;
        }

        protected IncomeCategory MapCategory(DbRef<IncomeCategoryEntity> categoryEntity)
        {
            if (categoryEntity != null)
            {
                var ce = dbProvider.FindById<IncomeCategoryEntity>(categoryEntity.Id);
                return translator.TranslateTo<IncomeCategory>(ce);
            }

            return null;
        }

        public Income FindById(int id)
        {
            var incomeEntity = dbProvider.FindById<IncomeEntity>(id);
            var income = translator.TranslateTo<Income>(incomeEntity);
            income.Person = MapPerson(incomeEntity.Person);
            income.Category = MapCategory(incomeEntity.Category);
            return income;
        }

        public void Add(Income income)
        {
            var incomeEntity = translator.TranslateTo<IncomeEntity>(income);
            UpdatePersonEntity(income.Person, incomeEntity.Person);
            UpdateCategory(income.Category, incomeEntity.Category);
            dbProvider.Insert(incomeEntity);
        }

        public void Update(Income income)
        {
            var incomeEntity = dbProvider.FindById<IncomeEntity>(income.Id);
            incomeEntity.Amount = income.Amount;
            incomeEntity.Description = income.Description;
            incomeEntity.Modified = income.Modified;

            UpdatePersonEntity(income.Person, incomeEntity.Person);
            UpdateCategory(income.Category, incomeEntity.Category);

            dbProvider.Update(incomeEntity);
        }

        public void Remove(Income income)
        {
            var entity = dbProvider.FindById<IncomeEntity>(income.Id);
            dbProvider.Delete(entity);
        }

        private void UpdateCategory(Category category, DbRef<IncomeCategoryEntity> categoryEntity)
        {
            if (category != null)
            {
                var entity = dbProvider.FindById<ExpenditureCategoryEntity>(category.Id);
                var categories = dbProvider.GetCollection<IncomeCategoryEntity>(typeof(IncomeCategoryEntity));
                categoryEntity = new DbRef<IncomeCategoryEntity>(categories, entity.Id);
            }
            else
            {
                categoryEntity = null;
            }
        }
    }
}