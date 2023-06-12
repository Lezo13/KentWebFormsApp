namespace KentWebForms.Services.Course.Tests
{
    using KentWebForms.Infrastructure.Entities.Courses;
    using KentWebForms.Infrastructure.Interfaces;
    using KentWebForms.Infrastructure.Models;
    using KentWebForms.Infrastructure.Models.Courses;
    using KentWebForms.Infrastructure.Requests.Courses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class CourseServiceTest
    {
        private CourseService target;
        private Mock<ICourseSqlDataGateway> gateway;

        [TestInitialize]
        public void Setup()
        {
            this.gateway = new Mock<ICourseSqlDataGateway>();

            this.target = new CourseService(this.gateway.Object);
        }

        [TestCleanup]
        public void TearDown()
        {
            this.gateway = null;

            this.target = null;
        }

        [TestMethod]
        public async Task GetCourseAsync_ValidModel_NoErrors()
        {
            this.gateway
                .Setup(s => s.GetCourseAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new CourseEntity());

            var actual = await this.target.GetCourseAsync(new GetCourseRequest());

            Assert.IsInstanceOfType(actual, typeof(Response<Course>));
        }

        [TestMethod]
        public async Task GetCoursesAsync_ValidModel_NoErrors()
        {
            this.gateway
                .Setup(s => s.GetCoursesAsync())
                .ReturnsAsync(new List<CourseEntity>());

            var actual = await this.target.GetCoursesAsync();

            Assert.IsInstanceOfType(actual, typeof(Response<IEnumerable<Course>>));
        }

        [TestMethod]
        public async Task GetUserCoursesAsync_ValidModel_NoErrors()
        {
            this.gateway
                .Setup(s => s.GetUserCoursesAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<UserCourseEntity>());

            var actual = await this.target.GetUserCoursesAsync(new GetUserCoursesRequest());

            Assert.IsInstanceOfType(actual, typeof(Response<IEnumerable<UserCourse>>));
        }

        [TestMethod]
        public async Task GetUserCourseAsync_ValidModel_NoErrors()
        {
            this.gateway
                .Setup(s => s.GetUserCourseAsync(It.IsAny<Guid>(), It.IsAny<string>()))
                .ReturnsAsync(new UserCourseEntity());

            var actual = await this.target.GetUserCourseAsync(new GetUserCourseRequest());

            Assert.IsInstanceOfType(actual, typeof(Response<UserCourse>));
        }

        [TestMethod]
        public async Task InsertUserCourseAsync_ValidModel_NoErrors()
        {
            this.gateway
                .Setup(s => s.InsertUserCourseAsync(It.IsAny<UserCourseEntity>()));

            var actual = await this.target.InsertUserCourseAsync(new UserCourse());

            Assert.IsInstanceOfType(actual, typeof(Response));
        }

        [TestMethod]
        public async Task UpdateUserCourseAsync_ValidModel_NoErrors()
        {
            this.gateway
                .Setup(s => s.UpdateUserCourseAsync(It.IsAny<UserCourseEntity>()));

            var actual = await this.target.UpdateUserCourseAsync(new UserCourse());

            Assert.IsInstanceOfType(actual, typeof(Response));
        }

        [TestMethod]
        public async Task DeleteUserCourseAsync_ValidModel_NoErrors()
        {
            this.gateway
                .Setup(s => s.DeleteUserCourseAsync(It.IsAny<Guid>(), It.IsAny<string>()));

            var actual = await this.target.DeleteUserCourseAsync(new DeleteUserCourseRequest());

            Assert.IsInstanceOfType(actual, typeof(Response));
        }
    }
}
