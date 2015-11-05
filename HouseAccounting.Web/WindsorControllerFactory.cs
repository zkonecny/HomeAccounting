using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace HouseAccounting.Web
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly WindsorContainer _container;

        public WindsorControllerFactory(WindsorContainer container)
        {
            _container = container;

        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            return _container.Resolve(controllerType) as IController;
        }
    }
}