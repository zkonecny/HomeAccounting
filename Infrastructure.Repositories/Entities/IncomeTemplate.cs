using System.Collections.Generic;
using LiteDB;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class IncomeTemplateEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        IEnumerable<IncomeTemplateItem> Items { get; set; }
    }
}
