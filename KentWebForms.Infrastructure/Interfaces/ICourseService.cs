namespace KentWebForms.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;

    public interface ICourseService
    {
        Task<Response<IEnumerable<Course>>> GetCoursesAsync();
    }
}
