namespace KentWebForms.App.Pages.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Owin;
    using KentWebForms.App.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var roleManager = Context.GetOwinContext().Get<ApplicationRoleManager>();
            var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Username.Text, Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text };
            IdentityResult result = userManager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                var selectedRole = Role.Text;
                var role = roleManager.FindByName(selectedRole);
                userManager.AddToRole(user.Id, role.Name);
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}