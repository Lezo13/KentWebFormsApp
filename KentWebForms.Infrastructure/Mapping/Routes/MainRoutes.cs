namespace KentWebForms.Infrastructure.Routing
{
    using System.Web.Routing;

    public static class MainRoutes
    {
        public static void MapRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("DefaultRoute", "Default.aspx", "~/Default.aspx");
        }
    }
}
