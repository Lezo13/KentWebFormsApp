namespace KentWebForms.App.Controllers
{
    using KentWebForms.Infrastructure.Interfaces;
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

        // GET: api/course/courses
        [HttpGet]
        [Route("courses")]
        public async Task<IHttpActionResult> GetCoursesAsync()
        {
            var result = await this.service.GetCoursesAsync();
            return Content((HttpStatusCode)result.StatusCode, result);
        }
    }
}
