using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Infrastructure.Repositories.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDbProvider>()
                .ImplementedBy<DbProvider>().LifestylePerWebRequest());

            container.Register(Component.For(typeof(IGenericRepository<>))
                .ImplementedBy(typeof(GenericRepository<>)).LifestylePerWebRequest());

            container.Register(Component.For(typeof(IPersonRepository))
                .ImplementedBy(typeof(PersonRepository)).LifestylePerWebRequest());
            container.Register(Component.For(typeof(ICategoryRepository))
                .ImplementedBy(typeof(CategoryRepository)).LifestylePerWebRequest());
        }
    }
}