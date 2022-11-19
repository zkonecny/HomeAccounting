using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class ExpenditureEntity : BaseEntity
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        [BsonRef(Collection = "ExpenditureCategoryEntity")]
        public ExpenditureCategoryEntity Category { get; set; }

        [BsonRef(Collection = "PersonEntity")]
        public PersonEntity Person { get; set; }
    }
}
