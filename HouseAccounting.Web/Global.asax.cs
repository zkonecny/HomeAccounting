using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using HouseAccounting.DTO.Translators.Installers;
using HouseAccounting.Infrastructure.Repositories.Installers;
using HouseAccounting.Web.Installers;

namespace HouseAccounting.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private WindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetupIoC();
            SetControllerFactory();
        }


        private void SetControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(this._container));
        }

        private void SetupIoC()
        {
            this._container = new WindsorContainer();

            this._container.Install(
                new RepositoriesInstaller(),
                new TranslatorsInstaller(),
                new WebInstaller()
                );
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

           // Log.Instance.LogError(exception);
        }


        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;

            if (application.Response.StatusCode != 401 || !application.Request.IsAuthenticated) return;

            var customErrors = (CustomErrorsSection)ConfigurationManager.GetSection("system.web/customErrors");

            var accessDeniedPath = customErrors.Errors["401"] != null ? customErrors.Errors["401"].Redirect : customErrors.DefaultRedirect;
            if (string.IsNullOrEmpty(accessDeniedPath))
                return; // Let other code handle it (probably IIS).

            application.Response.ClearContent();
            application.Server.Execute(accessDeniedPath);
            HttpContext.Current.Server.ClearError();
        }
    }
}
