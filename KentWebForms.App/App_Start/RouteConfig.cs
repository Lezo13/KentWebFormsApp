using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using KentWebForms.Infrastructure.Mapping.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace KentWebForms.App
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            MapRoutes(routes);
        }

        private static void MapRoutes(RouteCollection routes)
        {
            MainRoutes.MapRoutes(routes);
            AccountRoutes.MapRoutes(routes);
            ErrorRoutes.MapRoutes(routes);
        }
    }
}
