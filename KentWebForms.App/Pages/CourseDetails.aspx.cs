namespace KentWebForms.App.Pages
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.UI;
    using KentWebForms.App.Services;
    using KentWebForms.Infrastructure.HttpServices;
    using KentWebForms.Infrastructure.Models.Accounts;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;

    public partial class CourseDetails : Page
    {
        protected UserCourse userCourse;
        protected Course adminCourse;
        protected Guid courseId;
        protected bool IsAdminLoggedIn = false;

        private UserProfile userProfile;
        private CourseHttpService courseHttpService;

        public CourseDetails()
        {
            this.courseHttpService = new CourseHttpService();
        }

        protected void BackToCourses(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Courses");
        }

        protected void JoinCourse(object sender, EventArgs e)
        {
            this.InsertUserCourse();
        }

        protected void CompleteCourse(object sender, EventArgs e)
        {
            this.UpdateUserCourse();
        }

        protected void LeaveCourse(object sender, EventArgs e)
        {
            this.DeleteUserCourse();
        }

        protected string GetStatus(object dataItem)
        {
            var userItem = (CourseUser)dataItem;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var status = userItem.Status ?? "Join";

            return textInfo.ToTitleCase(status.ToLower());
        }

        protected string GetStatusClass(object dataItem)
        {
            var userItem = (CourseUser)dataItem;
            string statusClass = "default";
            var status = userItem.Status ?? "Join";

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
            var courseId = RouteData.Values["id"] as string;
            this.courseId = !string.IsNullOrEmpty(courseId) ? Guid.Parse(courseId) : Guid.Empty;

            if (this.courseId == Guid.Empty)
            {
                Response.Redirect("~/Courses");
            }

            this.CheckLoggedIn();
            this.userProfile = StorageService.GetUserProfile(Session);

            this.IsAdminLoggedIn = this.userProfile.RoleName.ToLower() == "admin";
            this.ResetButtonsDisplay();

            if (this.IsAdminLoggedIn)
            {
                this.LoadAdminCourse();
            }
            else
            {
                this.LoadUserCourse();
            }
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

        private async void LoadUserCourse()
        {
            var request = new GetUserCourseRequest { CourseId = this.courseId, UserId = this.userProfile.UserId };
            var response = await this.courseHttpService.GetUserCourse(request);
            this.userCourse = response.Data;
            this.SetImages(this.userCourse.CoverImgBase64, this.userCourse.DisplayImgBase64);
            this.ManageStatusDisplay();
        }

        private async void LoadAdminCourse()
        {
            var request = new GetCourseRequest { CourseId = this.courseId };
            var response = await this.courseHttpService.GetCourse(request);
            this.adminCourse = response.Data;
            this.SetImages(this.adminCourse.CoverImgBase64, this.adminCourse.DisplayImgBase64);
            userRepeater.DataSource = this.adminCourse.CourseUsers;
            userRepeater.DataBind();
        }

        private async void InsertUserCourse()
        {
            this.userCourse.UserId = this.userProfile.UserId;
            this.userCourse.Status = "In Progress";
            this.userCourse.DateEnrolled = DateTime.Now;
            var response = await this.courseHttpService.InsertUserCourse(this.userCourse);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                this.ManageStatusDisplay();
            }
        }

        private async void UpdateUserCourse()
        {
            this.userCourse.UserId = this.userProfile.UserId;
            this.userCourse.Status = "Completed";
            this.userCourse.DateCompleted = DateTime.Now;
            var response = await this.courseHttpService.UpdateUserCourse(this.userCourse);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                this.ManageStatusDisplay();
            }
        }

        private async void DeleteUserCourse()
        {
            var request = new DeleteUserCourseRequest { CourseId = this.userCourse.Id, UserId = this.userProfile.UserId};
            var response = await this.courseHttpService.DeleteUserCourse(request);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                this.userCourse.Status = null;
                this.userCourse.UserId = null;
                this.ManageStatusDisplay();
            }
          
        }

        private void ResetButtonsDisplay()
        {
            openBtns.Visible = false;
            joinedBtns.Visible = false;
            completedBtns.Visible = false;
            btnComplete.Visible = false;
            unlockLabel.Visible = false;
        }

        private void ManageStatusDisplay()
        {
            var status = this.userCourse.Status ?? string.Empty;

            this.ResetButtonsDisplay();

            switch (status.ToLower())
            {
                case "in progress":
                    joinedBtns.Visible = true;
                    btnComplete.Visible = true;
                    break;
                case "completed":
                    completedBtns.Visible = true;
                    break;
                case null:
                default:
                    unlockLabel.Visible = true;
                    openBtns.Visible = true;
                    break;
            }
        }

        private void SetImages(string coverImgBase64, string displayImgBase64)
        {
            string base64Format = "data:image/png;base64,{0}";
            string coverImgB64 = string.Format(base64Format, coverImgBase64);
            string displayImgB64 = string.Format(base64Format, displayImgBase64);

            coverImg.ImageUrl = coverImgB64;
            displayImg.ImageUrl = displayImgB64;
        }
    }
}