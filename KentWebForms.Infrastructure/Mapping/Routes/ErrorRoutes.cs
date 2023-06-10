namespace KentWebForms.Infrastructure.Mapping.Routing
{
    using System.Web.Routing;

    public static class ErrorRoutes
    {
        public static void MapRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("NotFoundRoute", "Not-Found", "~/Pages/Errors/NotFound.aspx");
        }
    }
}
