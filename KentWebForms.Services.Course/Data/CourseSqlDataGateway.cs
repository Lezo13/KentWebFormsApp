namespace KentWebForms.Services.Course.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Entities.Courses;
    using KentWebForms.Infrastructure.Helpers;
    using KentWebForms.Infrastructure.Interfaces;

    public class CourseSqlDataGateway : ICourseSqlDataGateway
    {
        private readonly ISqlHelper sql;

        public CourseSqlDataGateway(ISqlHelper sql)
        {
            this.sql = sql;
        }

        public async Task<CourseEntity> GetCourseAsync(Guid courseId)
        {
            var result = new CourseEntity();

            try
            {
                var command = CourseSqlCommandFactory.CreateGetCourseSqlCommand(courseId);
                result = await this.sql.ReadAsync<CourseEntity>(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task<IEnumerable<CourseEntity>> GetCoursesAsync()
        {
            var result = Enumerable.Empty<CourseEntity>();

            try
            {
                var command = CourseSqlCommandFactory.CreateGetCoursesSqlCommand();
                result = await this.sql.ReadAsListAsync<CourseEntity>(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task<IEnumerable<UserCourseEntity>> GetUserCoursesAsync(string userId)
        {
            var result = Enumerable.Empty<UserCourseEntity>();

            try
            {
                var command = CourseSqlCommandFactory.CreateGetUserCoursesSqlCommand(userId);
                result = await this.sql.ReadAsListAsync<UserCourseEntity>(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task<UserCourseEntity> GetUserCourseAsync(Guid courseId, string userId)
        {
            var result = new UserCourseEntity();

            try
            {
                var command = CourseSqlCommandFactory.CreateGetUserCourseSqlCommand(courseId, userId);
                result = await this.sql.ReadAsync<UserCourseEntity>(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task<IEnumerable<CourseUserEntity>> GetCourseUsersAsync(Guid courseId)
        {
            var result = Enumerable.Empty<CourseUserEntity>();

            try
            {
                var command = CourseSqlCommandFactory.CreateGetCourseUsersSqlCommand(courseId);
                result = await this.sql.ReadAsListAsync<CourseUserEntity>(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task InsertUserCourseAsync(UserCourseEntity entity)
        {
            try
            {
                var command = CourseSqlCommandFactory.CreateInsertUserCourseSqlCommand(entity);
                await this.sql.ExecuteAsync(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task UpdateUserCourseAsync(UserCourseEntity entity)
        {
            try
            {
                var command = CourseSqlCommandFactory.CreateUpdateUserCourseSqlCommand(entity);
                await this.sql.ExecuteAsync(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task DeleteUserCourseAsync(Guid courseId, string userId)
        {
            try
            {
                var command = CourseSqlCommandFactory.CreateDeleteUserCourseSqlCommand(courseId, userId);
                await this.sql.ExecuteAsync(command);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
