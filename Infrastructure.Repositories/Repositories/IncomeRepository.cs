//using System;
//using System.Collections.Generic;
//using System.Linq;
//using HouseAccounting.Infrastructure.Repositories.Entities;
//using HouseAccounting.Infrastructure.Repositories.Interfaces;
//using HouserAccounting.Business.Classes;
//using LiteDB;

//namespace HouseAccounting.Infrastructure.Repositories.Repositories
//{
//    public class IncomeRepository 
//    {
//        private readonly IDbProvider dbProvider;

//        public IncomeRepository(IDbProvider dbProvider)
//        {
//            this.dbProvider = dbProvider;
//        }

//        public IEnumerable<Income> GetAll()
//        {
//            List<Income> incomes = new List<Income>();

//            var entities = dbProvider.GetAll<IncomeEntity>();

//            foreach (var entity in entities)
//            {
//                var category = Mapper.Map(entity);

//                if (entity.Person != null)
//                {
//                    var personEntity = dbProvider.FindById<PersonEntity>(entity.Person.Id);
//                    category.Person = Mapper.Map(personEntity);
//                }

//                incomes.Add(category);
//            }

//            return incomes;
//        }

//        public Income FindById(int id)
//        {
//            var entity = dbProvider.FindById<IncomeEntity>(id);

//            return Mapper.Map(entity);
//        }

//        public void Add(Income domainEntity)
//        {
//            var entity = Mapper.Map(domainEntity);

//            UpdatePerson(domainEntity, entity);
//            UpdateCategory(domainEntity, entity);

//            dbProvider.Insert(entity);
//        }

//        private void UpdateCategory(Income domainEntity, IncomeEntity entity)
//        {
//            if (domainEntity.Category != null)
//            {
//                var category = dbProvider.FindById<IncomeCategoryEntity>(domainEntity.Category.Id);
//                var categories = dbProvider.GetCollection<IncomeCategoryEntity>(typeof (IncomeCategoryEntity));
//                entity.Category = new DbRef<IncomeCategoryEntity>(categories, category.Id);
//            }
//        }

//        private void UpdatePerson(Income domainEntity, IncomeEntity entity)
//        {
//            if (domainEntity.Person != null)
//            {
//                var person = dbProvider.FindById<PersonEntity>(domainEntity.Person.Id);
//                var persons = dbProvider.GetCollection<PersonEntity>(typeof (PersonEntity));
//                entity.Person = new DbRef<PersonEntity>(persons, person.Id);
//            }
//        }

//        public void Update(Income domainEntity)
//        {
//            var entity = dbProvider.FindById<IncomeEntity>(domainEntity.Id);
//            entity.Amount = domainEntity.Amount;
//            entity.Created = domainEntity.Created;

//            UpdatePerson(domainEntity, entity);
//            UpdateCategory(domainEntity, entity);

//            dbProvider.Update(entity);
//        }

//        public void Remove(Income domainEntity)
//        {
//            var entity = dbProvider.FindById<IncomeEntity>(domainEntity.Id);
//            dbProvider.Delete(entity);
//        }
//    }
//}