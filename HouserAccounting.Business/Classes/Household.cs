namespace HouserAccounting.Business.Classes
{
    public class Household : DomainEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
