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

        private DbRef<ExpenditureCategoryEntity> UpdateCategory(Category category)
        {
            DbRef<ExpenditureCategoryEntity> categoryEntity = null;
            if (category != null)
            {
                var entity = dbProvider.FindById<ExpenditureCategoryEntity>(category.Id);
                var categories = dbProvider.GetCollection<ExpenditureCategoryEntity>(typeof(ExpenditureCategoryEntity));
                categoryEntity = new DbRef<ExpenditureCategoryEntity>(categories, entity.Id);
            }

            return categoryEntity;
        }

        public IEnumerable<Expenditure> FindByDate(int year, int month)
        {
            List<Expenditure> expenditures = new List<Expenditure>();

            DateTime fromDate = new DateTime(year, month, 1);
            DateTime endDate = fromDate.AddMonths(1).AddDays(-1);

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

            return expenditures;
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