namespace KentWebForms.App
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Http;
    using System.Data.Entity;
    using KentWebForms.App.Models;
    using KentWebForms.App.Migrations;
    using KentWebForms.Infrastructure.Routing;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            this.HandleRouting();
        }

        void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                // Redirect to custom 404 page
                Server.ClearError();
                string notFoundPage = RouteHandler.GetNotFoundRoute();
                Response.Redirect(notFoundPage);
            }
        }

        private void HandleRouting()
        {
            string requestPath = Request.Path.ToLower().Replace(".aspx", string.Empty);

            if (RouteHandler.MatchRoute(requestPath))
            {
                string rewritePath = RouteHandler.GetRewritePath(requestPath);
                Context.RewritePath(rewritePath);
            }
        }
    }
}