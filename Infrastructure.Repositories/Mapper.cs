using System.ComponentModel;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories
{
    public  static class Mapper
    {
        public static Person Map(PersonEntity personEntity)
        {
            if (personEntity != null)
            {
                return new Person
                {
                    Id = personEntity.Id,
                    FirstName = personEntity.FirstName,
                    LastName = personEntity.LastName
                };
            }

            return null;
        }

        public static PersonEntity Map(Person person)
        {
            if (person != null)
            {
                return new PersonEntity
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                };
            }

            return null;
        }

        public static IncomeCategory Map(IncomeCategoryEntity categoryEntity)
        {
            if (categoryEntity != null)
            {
                return new IncomeCategory
                {
                    Id = categoryEntity.Id,
                    Name = categoryEntity.Name,
                    Description = categoryEntity.Description
                };
            }

            return null;
        }

        public static IncomeCategoryEntity Map(IncomeCategory category)
        {
            if (category != null)
            {
                return new IncomeCategoryEntity
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
            }

            return null;
        }

        public static ExpenditureCategory Map(ExpenditureCategoryEntity categoryEntity)
        {
            if (categoryEntity != null)
            {
                return new ExpenditureCategory
                {
                    Id = categoryEntity.Id,
                    Name = categoryEntity.Name,
                    Description = categoryEntity.Description
                };
            }

            return null;
        }

        public static ExpenditureCategoryEntity Map(ExpenditureCategory category)
        {
            if (category != null)
            {
                return new ExpenditureCategoryEntity
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
            }

            return null;
        }

        public static IncomeEntity Map(Income income)
        {
            if (income != null)
            {
                return new IncomeEntity
                {
                    Id = income.Id,
                    Amount = income.Amount,
                    Created = income.Created
                };
            }

            return null;
        }

        public static Income Map(IncomeEntity incomeEntity)
        {
            if (incomeEntity != null)
            {
                return new Income
                {
                    Id = incomeEntity.Id,
                    Amount = incomeEntity.Amount,
                    Created = incomeEntity.Created
                };
            }

            return null;
        }

        public static ExpenditureEntity Map(Expenditure income)
        {
            if (income != null)
            {
                return new ExpenditureEntity
                {
                    Id = income.Id,
                    Amount = income.Amount,
                    Created = income.Created
                };
            }

            return null;
        }

        public static Expenditure Map(ExpenditureEntity expenditureEntity)
        {
            if (expenditureEntity != null)
            {
                return new Expenditure
                {
                    Id = expenditureEntity.Id,
                    Amount = expenditureEntity.Amount,
                    Created = expenditureEntity.Created
                };
            }

            return null;
        }

        //public static TEntity Map<TDomainEntity, TEntity>(TEntity entity) where TDomainEntity : Category, new()
        //    where TEntity : BaseCategoryEntity, new()
        //{
        //    if (entity != null)
        //    {
        //        if (entity is IncomeCategoryEntity)
        //        {
        //            return new Income
        //            {
        //                Id = entity.Id,
        //                Amount = entity.Amount,
        //                Created = entity.Created
        //            };
        //        }
        //    }

        //    return null;
        //}
    }
}