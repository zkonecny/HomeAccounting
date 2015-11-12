using System.ComponentModel;
using HouseAccounting.Infrastructure.Repositories.Entities;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories
{
    public  static class Mapper
    {
        public static Person MapToPerson(PersonEntity personEntity)
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

        public static PersonEntity MapToPersonEntity(Person person)
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

        public static Category MapToCategory(CategoryEntity categoryEntity)
        {
            if (categoryEntity != null)
            {
                return new Category
                {
                    Id = categoryEntity.Id,
                    Name = categoryEntity.Name,
                    Description = categoryEntity.Description
                };
            }

            return null;
        }

        public static CategoryEntity MapToCategoryEntity(Category category)
        {
            if (category != null)
            {
                return new CategoryEntity
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
            }

            return null;
        }
    }
}