namespace KentWebForms.App.Controller.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KentWebForms.App.Controllers;
    using KentWebForms.Infrastructure.Interfaces;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Web.Http;

    [TestClass]
    public class CourseControllerTests
    {
        private CourseController target;
        private Mock<ICourseService> service;

        [TestInitialize]
        public void Initialize()
        {
            this.service = new Mock<ICourseService>();
            this.target = new CourseController(this.service.Object);
        }

        [TestMethod]
        public async Task GetCourseAsync_ValidModel_NoErrors()
        {
            this.service
                .Setup(s => s.GetCourseAsync(It.IsAny<GetCourseRequest>()))
                .ReturnsAsync(new Response<Course>());

            var actual = await this.target.GetCourseAsync(new GetCourseRequest());

            Assert.IsInstanceOfType(actual, typeof(IHttpActionResult));
        }

        [TestMethod]
        public async Task GetCoursesAsync_ValidModel_NoErrors()
        {
            this.service
                .Setup(s => s.GetCoursesAsync())
                .ReturnsAsync(new Response<IEnumerable<Course>>());

            var actual = await this.target.GetCoursesAsync();

            Assert.IsInstanceOfType(actual, typeof(IHttpActionResult));
        }

        [TestMethod]
        public async Task GetUserCoursesAsync_ValidModel_NoErrors()
        {
            this.service
                .Setup(s => s.GetUserCoursesAsync(It.IsAny<GetUserCoursesRequest>()))
                .ReturnsAsync(new Response<IEnumerable<UserCourse>>());

            var actual = await this.target.GetUserCoursesAsync(new GetUserCoursesRequest());

            Assert.IsInstanceOfType(actual, typeof(IHttpActionResult));
        }

        [TestMethod]
        public async Task GetUserCourseAsync_ValidModel_NoErrors()
        {
            this.service
                .Setup(s => s.GetUserCourseAsync(It.IsAny<GetUserCourseRequest>()))
                .ReturnsAsync(new Response<UserCourse>());

            var actual = await this.target.GetUserCourseAsync(new GetUserCourseRequest());

            Assert.IsInstanceOfType(actual, typeof(IHttpActionResult));
        }

        [TestMethod]
        public async Task InsertUserCourseAsync_ValidModel_NoErrors()
        {
            this.service
                .Setup(s => s.InsertUserCourseAsync(It.IsAny<UserCourse>()))
                .ReturnsAsync(new Response());

            var actual = await this.target.InsertUserCourseAsync(new UserCourse());

            Assert.IsInstanceOfType(actual, typeof(IHttpActionResult));
        }

        [TestMethod]
        public async Task UpdateUserCourseAsync_ValidModel_NoErrors()
        {
            this.service
                .Setup(s => s.UpdateUserCourseAsync(It.IsAny<UserCourse>()))
                .ReturnsAsync(new Response());

            var actual = await this.target.UpdateUserCourseAsync(new UserCourse());

            Assert.IsInstanceOfType(actual, typeof(IHttpActionResult));
        }

        [TestMethod]
        public async Task DeleteUserCourseAsync_ValidModel_NoErrors()
        {
            this.service
                .Setup(s => s.DeleteUserCourseAsync(It.IsAny<DeleteUserCourseRequest>()))
                .ReturnsAsync(new Response());

            var actual = await this.target.DeleteUserCourseAsync(new DeleteUserCourseRequest());

            Assert.IsInstanceOfType(actual, typeof(IHttpActionResult));
        }
    }
}
