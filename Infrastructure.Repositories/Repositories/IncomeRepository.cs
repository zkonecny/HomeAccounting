using System;
using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Business.Classes;
using LiteDB;
using System.Linq.Expressions;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class IncomeRepository : BaseRepository, IIncomeRepository
    {
        public IncomeRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
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

        protected IncomeCategory MapCategory(IncomeCategoryEntity categoryEntity)
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

        public IEnumerable<Income> FindByDate(int year, int month)
        {
            List<Income> incomes = new List<Income>();

            DateTime fromDate = new DateTime(year, month, 1);
            DateTime endDate = fromDate.AddMonths(1).Subtract(TimeSpan.FromSeconds(1));

            Expression<Func<IncomeEntity, bool>> predicate = incomeEntity
                => (incomeEntity.Created >= fromDate
                && incomeEntity.Created <= endDate);

            var incomeEntities = dbProvider.Find(predicate);

            foreach (var incomeEntity in incomeEntities)
            {
                Income income = translator.TranslateTo<Income>(incomeEntity);
                income.Person = MapPerson(incomeEntity.Person);
                income.Category = MapCategory(incomeEntity.Category);
                incomes.Add(income);
            }

            return incomes;
        }

        public void Add(Income income)
        {
            var incomeEntity = translator.TranslateTo<IncomeEntity>(income);
            incomeEntity.Person = UpdatePersonEntity(income.Person);
            incomeEntity.Category = UpdateCategory(income.Category);
            dbProvider.Insert(incomeEntity);
        }

        public void Update(Income income)
        {
            var incomeEntity = dbProvider.FindById<IncomeEntity>(income.Id);
            incomeEntity.Created = income.Created;
            incomeEntity.Amount = income.Amount;
            incomeEntity.Description = income.Description;
            incomeEntity.Modified = income.Modified;

            incomeEntity.Person = UpdatePersonEntity(income.Person);
            incomeEntity.Category = UpdateCategory(income.Category);

            dbProvider.Update(incomeEntity);
        }

        public void Remove(Income income)
        {
            var entity = dbProvider.FindById<IncomeEntity>(income.Id);
            dbProvider.Delete(entity);
        }

        private IncomeCategoryEntity UpdateCategory(Category category)
        {
           IncomeCategoryEntity categoryEntity = null;

            if (category != null)
            {
                var entity = dbProvider.FindById<IncomeCategoryEntity>(category.Id);
                categoryEntity = entity;
            }
            else
            {
                categoryEntity = null;
            }

            return categoryEntity;
        }
    }
}