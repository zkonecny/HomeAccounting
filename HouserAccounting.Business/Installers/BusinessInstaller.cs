using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HouseAccounting.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Business.Installers
{
        public class BusinessInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component.For<IMonthlyStatisticsService>()
                    .ImplementedBy<MonthlyStatisticsService>().LifestyleSingleton());
            }
        }
}
