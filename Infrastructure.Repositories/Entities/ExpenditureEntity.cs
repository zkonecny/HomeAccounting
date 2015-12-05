using System;
using HouserAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class ExpenditureEntity : BaseEntity
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        [BsonIndex]
        public DbRef<ExpenditureCategoryEntity> Category { get; set; }

        [BsonIndex]
        public DbRef<PersonEntity> Person { get; set; }
    }
}
