namespace KentWebForms.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Entities.Courses;

    public interface ICourseSqlDataGateway
    {
        Task<IEnumerable<CourseEntity>> GetCoursesAsync();
    }
}
