namespace KentWebForms.Infrastructure.Routing
{
    using KentWebForms.Infrastructure.Models.Routing;
    using System.Collections.Generic;

    public static class RouteMapping
    {
        public static List<RoutingModel> MainRoutes = new List<RoutingModel>()
        {
            CreateRoute("/default.aspx", "/Default.aspx"),
            CreateRoute("/about", "/About.aspx")
        };

        public static List<RoutingModel> AccountRoutes = new List<RoutingModel>()
        {
            CreateRoute("/account/login", "/Pages/Account/Login.aspx"),
            CreateRoute("/account/register", "/Pages/Account/Register.aspx")
        };

        public static List<RoutingModel> CourseRoutes = new List<RoutingModel>()
        {
            CreateRoute("/account/course", "/Pages/Account/Course.aspx")
        };

        public static List<RoutingModel> ErrorRoutes = new List<RoutingModel>()
        {
            CreateRoute("/not-found", "/Pages/Errors/NotFound.aspx")
        };

        private static RoutingModel CreateRoute(string route, string path)
        {
            return new RoutingModel { Route = route, Path = path };
        }
    }
}
