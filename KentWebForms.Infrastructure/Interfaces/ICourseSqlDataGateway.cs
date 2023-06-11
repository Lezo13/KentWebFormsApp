namespace KentWebForms.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Entities.Courses;

    public interface ICourseSqlDataGateway
    {
        Task<IEnumerable<UserCourseEntity>> GetUserCoursesAsync(string userId);

        Task<UserCourseEntity> GetUserCourseAsync(Guid courseId, string userId);

        Task InsertUserCourseAsync(UserCourseEntity entity);

        Task UpdateUserCourseAsync(UserCourseEntity entity);

        Task DeleteUserCourseAsync(Guid courseId, string userId);
    }
}
