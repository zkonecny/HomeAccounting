using System;
using HouseAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class IncomeEntity : BaseEntity
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        [BsonRef(Collection = "IncomeCategoryEntity")]
        public IncomeCategoryEntity Category { get; set; }

        [BsonRef(Collection = "PersonEntity")]
        public PersonEntity Person { get; set; }
    }
}
