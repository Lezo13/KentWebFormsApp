namespace KentWebForms.App.Pages
{
    using System;
    using System.Web;
    using System.Web.UI;
    using KentWebForms.App.Services;
    using KentWebForms.Infrastructure.HttpServices;
    using KentWebForms.Infrastructure.Models.Accounts;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;

    public partial class CourseDetails : Page
    {
        protected UserCourse course;
        protected Guid courseId;

        private UserProfile userProfile;
        private CourseHttpService courseHttpService;

        public CourseDetails()
        {
            this.courseHttpService = new CourseHttpService();
        }

        protected void JoinCourse(object sender, EventArgs e)
        {
            this.InsertUserCourse();
        }

        protected void CompleteCourse(object sender, EventArgs e)
        {
            this.UpdateUserCourse();
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
            this.LoadCourse();
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

        private async void LoadCourse()
        {
            var request = new GetUserCourseRequest { CourseId = this.courseId, UserId = this.userProfile.UserId };
            var response = await this.courseHttpService.GetUserCourse(request);
            this.course = response.Data;
            this.SetImages();
            this.ManageStatusDisplay();
        }

        private async void InsertUserCourse()
        {
            this.course.UserId = this.userProfile.UserId;
            this.course.Status = "In Progress";
            this.course.DateEnrolled = DateTime.Now;
            var response = await this.courseHttpService.InsertUserCourse(this.course);
            this.ManageStatusDisplay();
        }

        private async void UpdateUserCourse()
        {
            this.course.UserId = this.userProfile.UserId;
            this.course.Status = "Completed";
            this.course.DateCompleted = DateTime.Now;
            var response = await this.courseHttpService.UpdateUserCourse(this.course);
            this.ManageStatusDisplay();
        }

        private void ManageStatusDisplay()
        {
            var status = this.course.Status ?? string.Empty;

            openBtns.Visible = false;
            joinedBtns.Visible = false;
            completedBtns.Visible = false;
            btnComplete.Visible = false;
            unlockLabel.Visible = false;

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

        private void SetImages()
        {
            string base64Format = "data:image/png;base64,{0}";
            string coverImgB64 = string.Format(base64Format, this.course.CoverImgBase64);
            string displayImgB64 = string.Format(base64Format, this.course.DisplayImgBase64);

            coverImg.ImageUrl = coverImgB64;
            displayImg.ImageUrl = displayImgB64;
        }
    }
}