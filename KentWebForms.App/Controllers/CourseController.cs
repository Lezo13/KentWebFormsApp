namespace KentWebForms.App.Controllers
{
    using KentWebForms.Infrastructure.Interfaces;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;
    using System.Diagnostics;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        private readonly ICourseService service;

        public CourseController(ICourseService service)
        {
            Debug.Assert(service != null, "Null dependencies");
            this.service = service;
        }

        // GET: api/course/user_courses
        [HttpGet]
        [Route("user_courses")]
        public async Task<IHttpActionResult> GetUserCoursesAsync([FromUri] GetUserCoursesRequest request)
        {
            var result = await this.service.GetUserCoursesAsync(request);
            return Content((HttpStatusCode)result.StatusCode, result);
        }

        // GET: api/course/user_course
        [HttpGet]
        [Route("user_course")]
        public async Task<IHttpActionResult> GetUserCourseAsync([FromUri] GetUserCourseRequest request)
        {
            var result = await this.service.GetUserCourseAsync(request);
            return Content((HttpStatusCode)result.StatusCode, result);
        }

        // POST: api/course/user_course
        [HttpPost]
        [Route("user_course")]
        public async Task<IHttpActionResult> InsertUserCourseAsync([FromBody] UserCourse request)
        {
            var result = await this.service.InsertUserCourseAsync(request);
            return Content((HttpStatusCode)result.StatusCode, result);
        }

        // PUT: api/course/user_course
        [HttpPut]
        [Route("user_course")]
        public async Task<IHttpActionResult> UpdateUserCourseAsync([FromBody] UserCourse request)
        {
            var result = await this.service.UpdateUserCourseAsync(request);
            return Content((HttpStatusCode)result.StatusCode, result);
        }

        // DELETE: api/course/user_course
        [HttpDelete]
        [Route("user_course")]
        public async Task<IHttpActionResult> DeleteUserCourseAsync([FromUri] DeleteUserCourseRequest request)
        {
            var result = await this.service.DeleteUserCourseAsync(request);
            return Content((HttpStatusCode)result.StatusCode, result);
        }
    }
}
