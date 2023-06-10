namespace KentWebForms.App.Pages.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using KentWebForms.App.Models;
    using KentWebForms.Infrastructure.Constants;
    using KentWebForms.App.Services;

    public partial class Register : Page
    {
        protected void RegisterUser_Click(object sender, EventArgs e)
        {
            var roleManager = Context.GetOwinContext().Get<ApplicationRoleManager>();
            var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Username.Text, Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text };
            IdentityResult result = userManager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                StorageService.SetRecentRegistered(Session);
                var selectedRole = Role.Text;
                var role = roleManager.FindByName(selectedRole);
                userManager.AddToRole(user.Id, role.Name);
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                StorageService.SetLoginPrompt(Session);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response, true);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}