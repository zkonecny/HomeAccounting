using System;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}