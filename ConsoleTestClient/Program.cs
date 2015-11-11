using System;
using HouseAccounting.Infrastructure.Repositories;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace ConsoleTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbProvider dbProvider = new DbProvider();

            //IGenericRepository<Category> categoryRepository = new GenericRepository<Category>(dbProvider);

            //var allCategories = categoryRepository.GetAll();

            //Category category = new Category() { Description = "Osobni", Name = "Osobni" };
            //categoryRepository.Add(category);

            //var search = categoryRepository.FindById(category.Id);

            //categoryRepository.Remove(category);

            //foreach (var category in dbContext.Categories)
            //{
            //    Console.WriteLine(category.Name);
            //}

            Console.WriteLine("Finished, press any key...");
            Console.Read();
        }
    }
}
