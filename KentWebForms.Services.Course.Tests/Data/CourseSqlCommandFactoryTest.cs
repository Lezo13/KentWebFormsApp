namespace KentWebForms.Services.Course.Tests.Data
{
    using KentWebForms.Infrastructure.Entities.Courses;
    using KentWebForms.Services.Course.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;

    [TestClass]
    public class CourseSqlCommandFactoryTest
    {
        [TestMethod]
        public void CreateGetCourseSqlCommand_ValidModel_NoErrors()
        {
            var expected = "[sp_GetCourse]";

            var actual = CourseSqlCommandFactory.CreateGetCourseSqlCommand(It.IsAny<Guid>());

            Assert.AreEqual(expected, actual.CommandText);
        }

        [TestMethod]
        public void CreateGetCourseSqlCommand_ValidModel_CorrectParameterCount()
        {
            var expected = 1;

            var actual = CourseSqlCommandFactory.CreateGetCourseSqlCommand(It.IsAny<Guid>()).Parameters.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateGetCoursesSqlCommand_ValidModel_NoErrors()
        {
            var expected = "[sp_GetCourses]";

            var actual = CourseSqlCommandFactory.CreateGetCoursesSqlCommand();

            Assert.AreEqual(expected, actual.CommandText);
        }

        [TestMethod]
        public void CreateGetCoursesSqlCommand_ValidModel_CorrectParameterCount()
        {
            var expected = 0;

            var actual = CourseSqlCommandFactory.CreateGetCoursesSqlCommand().Parameters.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateGetUserCoursesSqlCommand_ValidModel_NoErrors()
        {
            var expected = "[sp_GetUserCourses]";

            var actual = CourseSqlCommandFactory.CreateGetUserCoursesSqlCommand(It.IsAny<string>());

            Assert.AreEqual(expected, actual.CommandText);
        }

        [TestMethod]
        public void CreateGetUserCoursesSqlCommand_ValidModel_CorrectParameterCount()
        {
            var expected = 1;

            var actual = CourseSqlCommandFactory.CreateGetUserCoursesSqlCommand(It.IsAny<string>()).Parameters.Count;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CreateGetUserCourseSqlCommand_ValidModel_NoErrors()
        {
            var expected = "[sp_GetUserCourse]";

            var actual = CourseSqlCommandFactory.CreateGetUserCourseSqlCommand(It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual.CommandText);
        }

        [TestMethod]
        public void CreateGetUserCourseSqlCommand_ValidModel_CorrectParameterCount()
        {
            var expected = 2;

            var actual = CourseSqlCommandFactory.CreateGetUserCourseSqlCommand(It.IsAny<Guid>(), It.IsAny<string>()).Parameters.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateInsertUserCourseSqlCommand_ValidModel_NoErrors()
        {
            var expected = "[sp_InsertUserCourse]";

            var actual = CourseSqlCommandFactory.CreateInsertUserCourseSqlCommand(new UserCourseEntity());

            Assert.AreEqual(expected, actual.CommandText);
        }

        [TestMethod]
        public void CreateInsertUserCourseSqlCommand_ValidModel_CorrectParameterCount()
        {
            var expected = 3;

            var actual = CourseSqlCommandFactory.CreateInsertUserCourseSqlCommand(new UserCourseEntity()).Parameters.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateUpdateUserCourseSqlCommand_ValidModel_NoErrors()
        {
            var expected = "[sp_UpdateUserCourse]";

            var actual = CourseSqlCommandFactory.CreateUpdateUserCourseSqlCommand(new UserCourseEntity());

            Assert.AreEqual(expected, actual.CommandText);
        }

        [TestMethod]
        public void CreateUpdateUserCourseSqlCommand_ValidModel_CorrectParameterCount()
        {
            var expected = 4;

            var actual = CourseSqlCommandFactory.CreateUpdateUserCourseSqlCommand(new UserCourseEntity()).Parameters.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateDeleteUserCourseSqlCommand_ValidModel_NoErrors()
        {
            var expected = "[sp_DeleteUserCourse]";

            var actual = CourseSqlCommandFactory.CreateDeleteUserCourseSqlCommand(It.IsAny<Guid>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual.CommandText);
        }

        [TestMethod]
        public void CreateDeleteUserCourseSqlCommand_ValidModel_CorrectParameterCount()
        {
            var expected = 2;

            var actual = CourseSqlCommandFactory.CreateDeleteUserCourseSqlCommand(It.IsAny<Guid>(), It.IsAny<string>()).Parameters.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
