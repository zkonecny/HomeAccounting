using System.Collections.Generic;
using HouseAccounting.Business.Classes;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public abstract class BaseCategoryEntity : BaseEntity
    {
        [BsonIndex]
        public string Name { get; set; }

        public string Description { get; set; }

        public DbRef<PersonEntity> Person { get; set; }
    }
}
