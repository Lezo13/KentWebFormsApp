namespace KentWebForms.Infrastructure.Routing
{
    using KentWebForms.Infrastructure.Models.Routing;
    using System.Collections.Generic;

    public static class RouteHandler
    {
        public static List<RoutingModel> AllRoutes { get { return GetAllRoutes(); } }

        public static bool MatchRoute(string requestPath)
        {
            return AllRoutes.Exists(r => r.Route == requestPath);
        }

        public static string GetRewritePath(string requestPath)
        {
            var data = AllRoutes.Find(r => r.Route == requestPath);
            return data.Path;
        }

        private static List<RoutingModel> GetAllRoutes()
        {
            List<RoutingModel> allRoutes = new List<RoutingModel>();

            allRoutes.AddRange(RouteMapping.MainRoutes);
            allRoutes.AddRange(RouteMapping.AccountRoutes);
            allRoutes.AddRange(RouteMapping.CourseRoutes);

            return allRoutes;
        }
    }
}
