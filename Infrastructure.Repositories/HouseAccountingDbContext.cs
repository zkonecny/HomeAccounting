using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HouseAccounting.Infrastructure.Repositories.DataClasses
{
    public class HouseAccountingDbContext : DbContext
    {
        // Pass database name you want to create in constructor or Pass connection string name if you want to set location and DB name from connection string
        // If nothing is passed in base constructor then it will create database with Namespacename.classname eg. "SchoolDataLayer.Context" in SQLExpress
        public HouseAccountingDbContext()
            : base("HouseAccounting")
        {
            //Database.SetInitializer<HouseAccountingDbContext>(new CreateDatabaseIfNotExists<HouseAccountingDBContext>());

            //Database.SetInitializer<HouseAccountingDbContext>(new DropCreateDatabaseIfModelChanges<HouseAccountingDbContext>());
            //Database.SetInitializer<HouseAccountingDbContext>(new DropCreateDatabaseAlways<HouseAccountingDbContext>());
            Database.SetInitializer<HouseAccountingDbContext>(new HouseAccountingDbInitializer());
        }

        public DbSet<HouseholdEntity> Houselholds { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<IncomeEntity> Income { get; set; }
        public DbSet<ExpenditureEntity> Expenditure { get; set; }

    }
}
