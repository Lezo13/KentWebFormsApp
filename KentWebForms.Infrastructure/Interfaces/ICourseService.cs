namespace KentWebForms.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;

    public interface ICourseService
    {
        Task<Response<Course>> GetCourseAsync(GetCourseRequest request);

        Task<Response<IEnumerable<Course>>> GetCoursesAsync();

        Task<Response<IEnumerable<UserCourse>>> GetUserCoursesAsync(GetUserCoursesRequest request);

        Task<Response<UserCourse>> GetUserCourseAsync(GetUserCourseRequest request);

        Task<Response> InsertUserCourseAsync(UserCourse request);

        Task<Response> UpdateUserCourseAsync(UserCourse request);

        Task<Response> DeleteUserCourseAsync(DeleteUserCourseRequest request);
    }
}
