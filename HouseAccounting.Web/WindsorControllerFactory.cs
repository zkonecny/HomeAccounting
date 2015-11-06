using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace HouseAccounting.Web
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly WindsorContainer container;

        public WindsorControllerFactory(WindsorContainer container)
        {
            this.container = container;

        }

        public override void ReleaseController(IController controller)
        {
            container.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            return container.Resolve(controllerType) as IController;
        }
    }
}