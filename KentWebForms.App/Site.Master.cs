namespace KentWebForms.App
{
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using KentWebForms.App.Services;
    using KentWebForms.Infrastructure.Models.Accounts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class SiteMaster : MasterPage
    {
        protected UserProfile userProfile;

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ManageNavBarDisplay();
            this.CheckRecentRegistration();
            this.CheckLoginPrompt();
            this.userProfile = StorageService.GetUserProfile(Session);
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        private void ManageNavBarDisplay()
        {
            string currentRoute = Request.Path.ToLower().TrimStart('/');

            if (currentRoute.StartsWith("not-found"))
            {
                navBar.Visible = false;
            }
            else
            {
                navBar.Visible = true;
            }
        }

        protected string GetFullName()
        {
            return string.Format("{0} {1}", this.userProfile.FirstName, this.userProfile.LastName);
        }

        private void CheckRecentRegistration()
        {
            if (StorageService.GetRecentRegistered(Session))
            {
                this.ShowSuccessToastr("Registered Successfully!", "Welcome");
                StorageService.ClearRecentRegistered(Session);
            }
        }

        private void CheckLoginPrompt()
        {
            if (StorageService.GetLoginPrompt(Session))
            {
                this.StoreUserProfile();
                StorageService.ClearLoginPrompt(Session);
            }
        }

        private void StoreUserProfile()
        {
            var userProfile = AccountService.CreateUserProfile(Context);
            if (userProfile != null)
            {
                StorageService.StoreUserProfile(Session, userProfile);
            }
        }

        private void ShowSuccessToastr(string message, string title)
        {
            string options = "{positionClass: 'toast-top-center', timeOut: 3000}";
            string script = string.Format("toastr.success('{0}', '{1}', {2});", message, title, options);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrSuccess", script, true);
        }
    }

}