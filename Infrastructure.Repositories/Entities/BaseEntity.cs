using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public int Id { get; set; }
    }
}