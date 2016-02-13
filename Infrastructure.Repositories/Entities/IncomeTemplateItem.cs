using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Infrastructure.Repositories.Entities
{
    public class IncomeTemplateItem : BaseEntity
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        [BsonIndex]
        public DbRef<IncomeCategoryEntity> Category { get; set; }

        [BsonIndex]
        public DbRef<PersonEntity> Person { get; set; }
    }
}
