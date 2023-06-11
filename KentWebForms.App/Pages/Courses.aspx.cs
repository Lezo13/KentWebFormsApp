namespace KentWebForms.App.Pages
{
    using KentWebForms.App.Services;
    using KentWebForms.Infrastructure.HttpServices;
    using KentWebForms.Infrastructure.Models.Accounts;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.UI;
  

    public partial class Courses : Page
    {
        protected List<UserCourse> courses;

        private UserProfile userProfile;
        private CourseHttpService courseHttpService;

        public Courses()
        {
            this.courseHttpService = new CourseHttpService();
        }

        protected string GetStatus(object dataItem)
        {
            var userCourse = (UserCourse)dataItem;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var status = userCourse.Status ?? "Join";

            return textInfo.ToTitleCase(status.ToLower());
        }

        protected string GetStatusClass(object dataItem)
        {
            var userCourse = (UserCourse)dataItem;
            string statusClass = "default";
            var status = userCourse.Status ?? "Join";

            switch (status.ToLower())
            {
                case "in progress":
                    statusClass = "in-progress";
                    break;
                case "completed":
                    statusClass = "completed";
                    break;
                case "join":
                    statusClass = "join";
                    break;
                default:
                    statusClass = "default";
                    break;
            }

            return statusClass;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckLoggedIn();
            this.userProfile = StorageService.GetUserProfile(Session);
            this.LoadCourses();
        }

        private void CheckLoggedIn()
        {
            var currentUser = HttpContext.Current.User;
            bool profileExist = StorageService.GetUserProfile(Session) != null;

            if (currentUser.Identity.IsAuthenticated && !profileExist)
            {
                this.StoreUserProfile();
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

        private async void LoadCourses()
        {
            var request = new GetUserCoursesRequest { UserId = this.userProfile.UserId };
            var response = await this.courseHttpService.GetUserCourses(request);
            this.courses = response.Data;
            cardRepeater.DataSource = this.courses;
            cardRepeater.DataBind();
        }
    }
}