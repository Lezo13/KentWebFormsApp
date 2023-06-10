namespace KentWebForms.Services.Course
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Interfaces;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Services.Faculty.Extensions;

    public class CourseService : ICourseService
    {
        private readonly ICourseSqlDataGateway gateway;

        public CourseService(ICourseSqlDataGateway gateway)
        {
            this.gateway = gateway;
        }

        public async Task<Response<IEnumerable<Course>>> GetCoursesAsync()
        {
            var result = new Response<IEnumerable<Course>>();

            try
            {
                result.Data = (await this.gateway.GetCoursesAsync()).AsModel();
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetFail(ex.Message);
                throw new Exception();
            }

            return result;
        }
    }
}
