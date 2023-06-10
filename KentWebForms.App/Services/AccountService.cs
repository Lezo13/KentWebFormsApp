namespace KentWebForms.App.Services
{
    using System.Web;
    using KentWebForms.Infrastructure.Models.Accounts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
  
    public static class AccountService
    {
        public static UserProfile CreateUserProfile(HttpContext context)
        {
            UserProfile userProfile = null;

            var currentUser = context.User;

            if (currentUser.Identity.IsAuthenticated)
            {
                var userManager = context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userManager.FindByName(currentUser.Identity.Name);
                var roles = userManager.GetRoles(user.Id);

                userProfile = new UserProfile
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    RoleName = roles[0]
                };
            }

            return userProfile;
        }
    }
}