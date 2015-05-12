using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using HouseAccounting.Infrastructure.Repositories.DataClasses;

namespace HouseAccounting.Infrastructure.Repositories
{
    internal class HouseAccountingDbInitializer : DropCreateDatabaseAlways<HouseAccountingDbContext>
    {
        protected override void Seed(HouseAccountingDbContext context)
        {
            IList<HouseholdEntity> defaultHouseholds = new List<HouseholdEntity>();

            defaultHouseholds.Add(new HouseholdEntity() { Name = "Rodina Konečná", Description = "Rodinný rozpočet rodiny Konečných" });

            foreach (HouseholdEntity std in defaultHouseholds)
            {
                context.Houselholds.Add(std);
            }

            //All default standards will be saved in base.Seed(context)
            base.Seed(context);
        
        }
    }

}
