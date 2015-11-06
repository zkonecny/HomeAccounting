using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace HouseAccounting.Web.Installers
{
    public class WebInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // All controllers
            container.Register(Classes.FromThisAssembly()
                  .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                  .LifestyleTransient());
        }
    }
}