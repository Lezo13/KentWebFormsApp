namespace KentWebForms.Infrastructure.Routing
{
    using System.Web.Routing;

    public static class AccountRoutes
    {
        public static void MapRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("RegisterRoute", "Account/Register", "~/Pages/Account/Register.aspx");
            routes.MapPageRoute("LoginRoute", "Account/Login", "~/Pages/Account/Login.aspx");
        }
    }
}
