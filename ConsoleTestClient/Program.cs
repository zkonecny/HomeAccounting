using System;
using System.Collections.Generic;
using System.Linq;

using HouseAccounting.Infrastructure.Repositories.DataClasses;
using HouseAccounting.Model.Classes;
using HouseAccounting.Model.Repositories;

namespace ConsoleTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HouseAccountingDbContext dbContext = new HouseAccountingDbContext();

            IGenericRepository<Category> categoryRepository = new HouseAccounting.Infrastructure.Repositories.Repositories.GenericRepository<Category, CategoryEntity>(dbContext);
            var result = categoryRepository.FindById(1);

            foreach (HouseholdEntity item in dbContext.Houselholds)
            {
               // Console.WriteLine(item.Name);
            }

            Console.WriteLine("Finished, press any key...");
            Console.Read();
        }
    }
}
