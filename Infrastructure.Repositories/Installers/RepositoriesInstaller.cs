using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Infrastructure.Repositories.Translator;

namespace HouseAccounting.Infrastructure.Repositories.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDbProvider>()
                .ImplementedBy<DbProvider>().LifestylePerWebRequest());

            container.Register(Component.For(typeof(IPersonRepository))
                .ImplementedBy(typeof(PersonRepository)));
            container.Register(Component.For(typeof(IIncomeCategoryRepository))
                .ImplementedBy(typeof(IncomeCategoryRepository)));
            container.Register(Component.For(typeof(IExpenditureCategoryRepository))
                .ImplementedBy(typeof(ExpenditureCategoryRepository)));
            container.Register(Component.For(typeof(IIncomeRepository))
                .ImplementedBy(typeof(IncomeRepository)));
            container.Register(Component.For(typeof(IExpenditureRepository))
                .ImplementedBy(typeof(CachedExpenditureRepository)));

            container.Register(Component.For(typeof(IEntityTranslator))
                .ImplementedBy(typeof(EntityTranslator)).LifestyleSingleton());

        }
    }
}