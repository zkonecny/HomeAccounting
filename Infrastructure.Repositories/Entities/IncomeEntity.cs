using System;
using HouseAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class IncomeEntity : BaseEntity
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        [BsonIndex]
        public DbRef<IncomeCategoryEntity> Category { get; set; }

        [BsonIndex]
        public DbRef<PersonEntity> Person { get; set; }
    }
}
