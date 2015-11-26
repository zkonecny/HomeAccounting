﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Infrastructure.Repositories.Translator;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Infrastructure.Repositories.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDbProvider>()
                .ImplementedBy<DbProvider>().LifestylePerWebRequest());

            container.Register(Component.For(typeof(IPersonRepository))
                .ImplementedBy(typeof(PersonRepository)).LifestylePerWebRequest());
            container.Register(Component.For(typeof(IIncomeCategoryRepository))
                .ImplementedBy(typeof(IncomeCategoryRepository)).LifestylePerWebRequest());
            container.Register(Component.For(typeof(IExpenditureCategoryRepository))
                .ImplementedBy(typeof(ExpenditureCategoryRepository)).LifestylePerWebRequest());

            container.Register(Component.For(typeof(IEntityTranslator))
                .ImplementedBy(typeof(EntityTranslator)).LifestyleSingleton());

        }
    }
}