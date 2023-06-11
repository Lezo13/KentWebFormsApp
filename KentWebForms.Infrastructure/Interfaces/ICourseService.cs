namespace KentWebForms.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;

    public interface ICourseService
    {
        Task<Response<IEnumerable<UserCourse>>> GetUserCoursesAsync(GetUserCoursesRequest request);

        Task<Response<UserCourse>> GetUserCourseAsync(GetUserCourseRequest request);
    }
}
