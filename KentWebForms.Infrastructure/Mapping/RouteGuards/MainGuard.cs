namespace KentWebForms.Infrastructure.Mapping.RouteGuards
{
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
    }
}
