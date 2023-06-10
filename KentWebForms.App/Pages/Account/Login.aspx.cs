namespace KentWebForms.App.Pages.Account
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using KentWebForms.App.Services;
    using KentWebForms.Infrastructure.Models.Accounts;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var loginModel = new LoginModel()
                {
                    Username = Username.Text,
                    Password = Password.Text,
                    RememberMe = RememberMe.Checked
                };

                var result = signinManager.PasswordSignIn(loginModel.Username, loginModel.Password, loginModel.RememberMe, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        StorageService.SetLoginPrompt(Session);
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response, true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        protected void ValidatePassword(object source, ServerValidateEventArgs args)
        {
            string password = Password.Text.Trim();
            if (string.IsNullOrEmpty(password))
            {
                Password.CssClass += " validation-failed";
                args.IsValid = false;
            }
            else
            {
                Password.CssClass = Password.CssClass.Replace(" validation-failed", "");
                args.IsValid = true;
            }
        }
    }
}