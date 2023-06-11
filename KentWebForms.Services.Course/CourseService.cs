namespace KentWebForms.Services.Course
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Interfaces;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;
    using KentWebForms.Services.Faculty.Extensions;

    public class CourseService : ICourseService
    {
        private readonly ICourseSqlDataGateway gateway;

        public CourseService(ICourseSqlDataGateway gateway)
        {
            this.gateway = gateway;
        }

        public async Task<Response<IEnumerable<UserCourse>>> GetUserCoursesAsync(GetUserCoursesRequest request)
        {
            var result = new Response<IEnumerable<UserCourse>>();

            try
            {
                result.Data = (await this.gateway.GetUserCoursesAsync(request.UserId)).AsModel();
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetFail(ex.Message);
                throw new Exception();
            }

            return result;
        }

        public async Task<Response<UserCourse>> GetUserCourseAsync(GetUserCourseRequest request)
        {
            var result = new Response<UserCourse>();

            try
            {
                result.Data = (await this.gateway.GetUserCourseAsync(request.CourseId, request.UserId)).AsModel();
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
