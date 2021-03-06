﻿using System;
using System.Collections.Generic;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Business.Classes;
using System.Linq.Expressions;
using System.Linq;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class ExpenditureRepository : BaseRepository, IExpenditureRepository
    {
        public ExpenditureRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
        }

        public virtual IEnumerable<Expenditure> GetAll()
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

        protected ExpenditureCategory MapCategory(ExpenditureCategoryEntity categoryEntity)
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
            expenditureEntity.Person = UpdatePersonEntity(expenditure.Person);
            expenditureEntity.Category = UpdateCategory(expenditure.Category);
            dbProvider.Insert(expenditureEntity);
        }

        public void Update(Expenditure expenditure)
        {
            var expenditureEntity = dbProvider.FindById<ExpenditureEntity>(expenditure.Id);
            expenditureEntity.Amount = expenditure.Amount;
            expenditureEntity.Description = expenditure.Description;
            expenditureEntity.Modified = expenditure.Modified;

            expenditureEntity.Person = UpdatePersonEntity(expenditure.Person);
            expenditureEntity.Category = UpdateCategory(expenditure.Category);

            dbProvider.Update(expenditureEntity);
        }

        public void Remove(Expenditure expenditure)
        {
            var entity = dbProvider.FindById<ExpenditureEntity>(expenditure.Id);
            dbProvider.Delete(entity);
        }

        private ExpenditureCategoryEntity UpdateCategory(Category category)
        {
            ExpenditureCategoryEntity categoryEntity = null;
            if (category != null)
            {
                var entity = dbProvider.FindById<ExpenditureCategoryEntity>(category.Id);
                categoryEntity = entity;
            }

            return categoryEntity;
        }

        public IEnumerable<Expenditure> FindByDate(int year, int month)
        {
            List<Expenditure> expenditures = new List<Expenditure>();

            DateTime fromDate = new DateTime(year, month, 1);
            DateTime endDate = fromDate.AddMonths(1).Subtract(TimeSpan.FromSeconds(1));

            Expression<Func<ExpenditureEntity, bool>> predicate = expenditureEntity
                => (expenditureEntity.Created >= fromDate
                && expenditureEntity.Created <= endDate);

            var expenditureEntities = dbProvider.Find(predicate);

            foreach (var expenditureEntity in expenditureEntities)
            {
                Expenditure expenditure = translator.TranslateTo<Expenditure>(expenditureEntity);
                expenditure.Person = MapPerson(expenditureEntity.Person);
                expenditure.Category = MapCategory(expenditureEntity.Category);
                expenditures.Add(expenditure);
            }

            return expenditures.ToList();
        }

        public IEnumerable<Expenditure> Find(Expression<Func<Expenditure, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {

            //var y = AddBox(predicate);
            //var a = y.Compile()(predicate)

            //var expenditureEntities = dbProvider.Find<ExpenditureEntity>(predicate, skip, limit);
            //var expenditure = translator.TranslateTo<Expenditure>(expenditureEntity);
            //expenditure.Person = MapPerson(expenditureEntity.Person);
            //expenditure.Category = MapCategory(expenditureEntity.Category);
            //return expenditure;
            return null;
        }

        static Expression<Func<TInput, object>> AddBox<TInput, TOutput>(Expression<Func<TInput, TOutput>> expression)
        {
            // Add the boxing operation, but get a weakly typed expression
            Expression converted = Expression.Convert
                 (expression.Body, typeof(object));
            // Use Expression.Lambda to get back to strong typing
            return Expression.Lambda<Func<TInput, object>>
                 (converted, expression.Parameters);
        }

        public IEnumerable<Expenditure> Find<Expenditure>(Expression<Func<Expenditure, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            throw new NotImplementedException();
        }
    }
}