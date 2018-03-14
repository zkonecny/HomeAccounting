using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HouseAccounting.Business.Classes;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Infrastructure.Repositories.Entities;
using LiteDB;
using System.Diagnostics;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public class CachedExpenditureRepository : ExpenditureRepository
    {
        private Dictionary<int, Person> persons;
        private Dictionary<int, ExpenditureCategory> categories;

        public CachedExpenditureRepository(IDbProvider dbProvider, IEntityTranslator translator)
            : base(dbProvider, translator)
        {
            persons = new Dictionary<int, Person>();
            categories = new Dictionary<int, ExpenditureCategory>();
        }

        public override IEnumerable<Expenditure> GetAll()
        {
            List<Expenditure> expenditures = new List<Expenditure>();

            var entities = dbProvider.GetAll<ExpenditureEntity>();

            foreach (var expenditureEntity in entities)
            {
                var expenditure = translator.TranslateTo<Expenditure>(expenditureEntity);
                expenditure.Person = GetCachedPerson(expenditureEntity.Person);
                expenditure.Category = GetCachedExpenditureCategory(expenditureEntity.Category);
                expenditures.Add(expenditure);
            }
    
            return expenditures;
        }

        private Person GetCachedPerson(PersonEntity personEntity)
        {
            Person person = null;
            if (personEntity != null)
            {
                if (persons.ContainsKey(personEntity.Id))
                {
                    return persons[personEntity.Id];
                }

                person = MapPerson(personEntity);
                persons[personEntity.Id] = person;
            }
            return person;
        }

        private ExpenditureCategory GetCachedExpenditureCategory(ExpenditureCategoryEntity expenditureCategoryEntity)
        {
            ExpenditureCategory expenditureCategory = null;
            if (expenditureCategoryEntity != null)
            {
                if (categories.ContainsKey(expenditureCategoryEntity.Id))
                {
                    return categories[expenditureCategoryEntity.Id];
                }

                expenditureCategory = MapCategory(expenditureCategoryEntity);
                categories[expenditureCategoryEntity.Id] = expenditureCategory;
            }
            return expenditureCategory;
        }
    }
}
