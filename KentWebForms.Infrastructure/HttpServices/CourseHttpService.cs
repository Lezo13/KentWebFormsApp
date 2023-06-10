namespace KentWebForms.Infrastructure.HttpServices
{
    using KentWebForms.Infrastructure.Helper;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CourseHttpService
    {
        public async Task<Response<List<Course>>> GetCourses()
        {
            string apiRoute = "course/courses";
            var response = await HttpHelper.Get<List<Course>>(apiRoute);
            return response;
        }
    }
}
