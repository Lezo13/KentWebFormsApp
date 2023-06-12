namespace KentWebForms.Services.Course.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using KentWebForms.Infrastructure.Entities.Courses;
    using KentWebForms.Infrastructure.Helpers;
    using KentWebForms.Services.Course.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CourseSqlDataGatewayTest
    {
        private CourseSqlDataGateway target;
        private Mock<ISqlHelper> sqlHelper;

        [TestInitialize]
        public void Setup()
        {
            this.sqlHelper = new Mock<ISqlHelper>();

            this.target = new CourseSqlDataGateway(this.sqlHelper.Object);
        }

        [TestCleanup]
        public void TearDown()
        {
            this.sqlHelper = null;

            this.target = null;
        }

        [TestMethod]
        public async Task GetCourseAsync_ValidParameters_ReadAsyncVerified()
        {
            var actual = await this.target.GetCourseAsync(It.IsAny<Guid>());
            this.sqlHelper.Verify(s => s.ReadAsync<CourseEntity>(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task GetCourseAsync_MethodDoesNotThrowExceptions_ReturnsEntity()
        {
            this.sqlHelper.Setup(s => s.ReadAsync<CourseEntity>(It.IsAny<SqlCommand>())).ReturnsAsync(new CourseEntity());
            var expected = await this.target.GetCourseAsync(It.IsAny<Guid>());
            Assert.IsInstanceOfType(expected, typeof(CourseEntity));
        }

        [TestMethod]
        public async Task GetCoursesAsync_ValidParameters_ReadAsListAsyncVerified()
        {
            var actual = await this.target.GetCoursesAsync();
            this.sqlHelper.Verify(s => s.ReadAsListAsync<CourseEntity>(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task GetCoursesAsync_MethodDoesNotThrowExceptions_ReturnsEntities()
        {
            this.sqlHelper.Setup(s => s.ReadAsListAsync<CourseEntity>(It.IsAny<SqlCommand>())).ReturnsAsync(new List<CourseEntity>());
            var expected = await this.target.GetCoursesAsync();
            Assert.IsInstanceOfType(expected, typeof(IEnumerable<CourseEntity>));
        }

        [TestMethod]
        public async Task GetUserCoursesAsync_ValidParameters_ReadAsListAsyncVerified()
        {
            var actual = await this.target.GetUserCoursesAsync(It.IsAny<string>());
            this.sqlHelper.Verify(s => s.ReadAsListAsync<UserCourseEntity>(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task GetUserCoursesAsync_MethodDoesNotThrowExceptions_ReturnsEntities()
        {
            this.sqlHelper.Setup(s => s.ReadAsListAsync<UserCourseEntity>(It.IsAny<SqlCommand>())).ReturnsAsync(new List<UserCourseEntity>());
            var expected = await this.target.GetUserCoursesAsync(It.IsAny<string>());
            Assert.IsInstanceOfType(expected, typeof(IEnumerable<UserCourseEntity>));
        }

        [TestMethod]
        public async Task GetUserCourseAsync_ValidParameters_ReadAsyncVerified()
        {
            var actual = await this.target.GetUserCourseAsync(It.IsAny<Guid>(), It.IsAny<string>());
            this.sqlHelper.Verify(s => s.ReadAsync<UserCourseEntity>(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task GetUserCourseAsync_MethodDoesNotThrowExceptions_ReturnsEntity()
        {
            this.sqlHelper.Setup(s => s.ReadAsync<UserCourseEntity>(It.IsAny<SqlCommand>())).ReturnsAsync(new UserCourseEntity());
            var expected = await this.target.GetUserCourseAsync(It.IsAny<Guid>(), It.IsAny<string>());
            Assert.IsInstanceOfType(expected, typeof(UserCourseEntity));
        }

        [TestMethod]
        public async Task GetCourseUsersAsync_ValidParameters_ReadAsListAsyncVerified()
        {
            var actual = await this.target.GetCourseUsersAsync(It.IsAny<Guid>());
            this.sqlHelper.Verify(s => s.ReadAsListAsync<CourseUserEntity>(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task GetCourseUsersAsync_MethodDoesNotThrowExceptions_ReturnsEntities()
        {
            this.sqlHelper.Setup(s => s.ReadAsListAsync<CourseUserEntity>(It.IsAny<SqlCommand>())).ReturnsAsync(new List<CourseUserEntity>());
            var expected = await this.target.GetCourseUsersAsync(It.IsAny<Guid>());
            Assert.IsInstanceOfType(expected, typeof(IEnumerable<CourseUserEntity>));
        }

        [TestMethod]
        public async Task InsertUserCourseAsync_ValidParameters_ExecuteAsyncVerified()
        {
            await this.target.InsertUserCourseAsync(new UserCourseEntity());
            this.sqlHelper.Verify(s => s.ExecuteAsync(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task InsertUserCourseAsync_MethodDoesNotThrowExceptions_DoesNotReturnEntity()
        {
            this.sqlHelper.Setup(s => s.ExecuteAsync(It.IsAny<SqlCommand>()));
            await this.target.InsertUserCourseAsync(new UserCourseEntity());
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task UpdateUserCourseAsync_ValidParameters_ExecuteAsyncVerified()
        {
            await this.target.UpdateUserCourseAsync(new UserCourseEntity());
            this.sqlHelper.Verify(s => s.ExecuteAsync(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task UpdateUserCourseAsync_MethodDoesNotThrowExceptions_DoesNotReturnEntity()
        {
            this.sqlHelper.Setup(s => s.ExecuteAsync(It.IsAny<SqlCommand>()));
            await this.target.UpdateUserCourseAsync(new UserCourseEntity());
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task DeleteUserCourseAsync_ValidParameters_ExecuteAsyncVerified()
        {
            await this.target.DeleteUserCourseAsync(It.IsAny<Guid>(), It.IsAny<string>());
            this.sqlHelper.Verify(s => s.ExecuteAsync(It.IsAny<SqlCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task DeleteUserCourseAsync_MethodDoesNotThrowExceptions_DoesNotReturnEntity()
        {
            this.sqlHelper.Setup(s => s.ExecuteAsync(It.IsAny<SqlCommand>()));
            await this.target.DeleteUserCourseAsync(It.IsAny<Guid>(), It.IsAny<string>());
            Assert.IsTrue(true);
        }
    }
}
