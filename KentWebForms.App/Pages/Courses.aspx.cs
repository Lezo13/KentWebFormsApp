namespace KentWebForms.App.Pages
{
    using KentWebForms.Infrastructure.HttpServices;
    using KentWebForms.Infrastructure.Models.Courses;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.UI;
  

    public partial class Courses : Page
    {
        private CourseHttpService courseHttpService;
        protected List<Course> courses;

        public Courses()
        {
            this.courseHttpService = new CourseHttpService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadCourses();
        }

        private async void LoadCourses()
        {
            var response = await this.courseHttpService.GetCourses();
            this.courses = response.Data;
            cardRepeater.DataSource = this.courses;
            cardRepeater.DataBind();
        }
    }
}