using System;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class IncomeEntity : BaseEntity
    {
        [BsonIndex]
        public DateTime Created { get; set; }

        public int Amount { get; set; }

        [BsonIndex]
        public DbRef<IncomeCategoryEntity> Category { get; set; }

        [BsonIndex]
        public DbRef<PersonEntity> Person { get; set; }
    }
}
