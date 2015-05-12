using HouseAccounting.Model.Interfaces;

namespace HouseAccounting.Model.Classes
{
    public class Category : IDomainEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
