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
    }
}
