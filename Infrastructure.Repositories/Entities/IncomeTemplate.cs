using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class IncomeTemplateEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        IEnumerable<IncomeTemplateItem> Items { get; set; }
    }
}
