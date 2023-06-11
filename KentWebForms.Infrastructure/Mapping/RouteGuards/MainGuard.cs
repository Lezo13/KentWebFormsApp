namespace KentWebForms.Infrastructure.Mapping.RouteGuards
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;

    public static class MainGuard
    {
        public static bool BlockRoute(IPrincipal user, HttpRequest httpRequest)
        {
            // List all blocked conditions

            string currentRoute = httpRequest.Path.ToLower().TrimStart('/');
            var isAuthenticated = user.Identity.IsAuthenticated;

            if (!isAuthenticated && (currentRoute.StartsWith("courses") && !currentRoute.Contains("api")))
            {
                return true;
            }

            return false;
        }

        public static string RedirectRoute(IPrincipal user, HttpRequest httpRequest)
        {
            string currentRoute = httpRequest.Path.ToLower().TrimStart('/');
            var isAuthenticated = user.Identity.IsAuthenticated;
            string redirectPath = string.Empty;

            // Prevent Logged in user to access the specifed routes
            var nonUserRoutes = new List<string>{ "default", "account/login", "account/register" };
            if (isAuthenticated && nonUserRoutes.Any(t => currentRoute.StartsWith(t)))
            {
                redirectPath = "~/Courses";
            }


            return redirectPath;
        }
    }
}
