namespace KentWebForms.App
{
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using KentWebForms.Infrastructure.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class SiteMaster : MasterPage
    {
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
            this.CheckRecentRegistration();
            this.ManageNavBarDisplay();
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
            var currentUser = HttpContext.Current.User;
         
            string fullName = "No name specified";

            if (currentUser != null)
            {
                var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userManager.FindByName(currentUser.Identity.Name);
                fullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            }

            return fullName;
        }

        protected string GetRoleName()
        {
            var currentUser = HttpContext.Current.User;

            string roleName = "Unassigned";

            if (currentUser.Identity.IsAuthenticated)
            {
                var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var roleManager = Context.GetOwinContext().Get<ApplicationRoleManager>();
                var user = userManager.FindByName(currentUser.Identity.Name);
                if (user != null)
                {
                    var roles = userManager.GetRoles(user.Id);

                    roleName = roles[0];
                }
            }

            return roleName;
        }

        private void CheckRecentRegistration()
        {
            if (Session[RegistrationConstants.RecentlyRegistered] != null && (bool)Session[RegistrationConstants.RecentlyRegistered])
            {
                this.ShowSuccessToastr("Registered Successfully!", "Welcome");
                Session.Remove(RegistrationConstants.RecentlyRegistered);
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