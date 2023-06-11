namespace KentWebForms.Infrastructure.Mapping.Routing
{
    using System.Web.Routing;

    public static class MainRoutes
    {
        public static void MapRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("DefaultRoute", "Default.aspx", "~/Default.aspx");
            routes.MapPageRoute("Courses", "Courses", "~/Pages/Courses.aspx");
            routes.MapPageRoute("CourseDetails", "courses/{id}", "~/Pages/CourseDetails.aspx");
        }
    }
}
