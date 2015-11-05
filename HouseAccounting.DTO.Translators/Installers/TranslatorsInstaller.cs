using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace HouseAccounting.DTO.Translators.Installers
{
    public class TranslatorsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITranslator>()
                .ImplementedBy<SimpleTranslator>().LifestyleSingleton());
        }
    }
}