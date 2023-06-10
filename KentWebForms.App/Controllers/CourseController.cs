namespace KentWebForms.App.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        public CourseController()
        {
        }

        // GET: api/course/courses
        [HttpGet]
        [Route("courses")]
        public async Task<IHttpActionResult> GetCoursesAsync()
        {
            /* Insert Logic to Get Courses Here  */
            return Ok();
        }
    }
}
