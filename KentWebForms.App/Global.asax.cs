using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity;
using KentWebForms.App.Models;
using KentWebForms.App.Migrations;
using KentWebForms.Infrastructure.Routing;

namespace KentWebForms.App
{
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

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            this.HandleRouting();
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