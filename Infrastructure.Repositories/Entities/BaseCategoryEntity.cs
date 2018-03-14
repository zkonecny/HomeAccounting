using System.Collections.Generic;
using HouseAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public abstract class BaseCategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [BsonRef(Collection = "PersonEntity")]
        public PersonEntity Person { get; set; }
    }
}
