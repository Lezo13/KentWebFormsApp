namespace KentWebForms.Services.Course.Data
{
    using KentWebForms.Infrastructure.Entities.Courses;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class CourseSqlCommandFactory
    {
        public static SqlCommand CreateGetCourseSqlCommand(Guid courseId)
        {
            var result = new SqlCommand("[sp_GetCourse]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            result.Parameters.AddWithValue("@courseId", courseId);

            return result;
        }

        public static SqlCommand CreateGetCoursesSqlCommand()
        {
            var result = new SqlCommand("[sp_GetCourses]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            return result;
        }

        public static SqlCommand CreateGetUserCoursesSqlCommand(string userId)
        {
            var result = new SqlCommand("[sp_GetUserCourses]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            result.Parameters.AddWithValue("@userId", userId);

            return result;
        }

        public static SqlCommand CreateGetUserCourseSqlCommand(Guid courseId, string userId)
        {
            var result = new SqlCommand("[sp_GetUserCourse]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            result.Parameters.AddWithValue("@courseId", courseId);
            result.Parameters.AddWithValue("@userId", userId);

            return result;
        }

        public static SqlCommand CreateGetCourseUsersSqlCommand(Guid courseId)
        {
            var result = new SqlCommand("[sp_GetCourseUsers]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            result.Parameters.AddWithValue("@courseId", courseId);

            return result;
        }

        public static SqlCommand CreateInsertUserCourseSqlCommand(UserCourseEntity entity)
        {
            var result = new SqlCommand("[sp_InsertUserCourse]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            result.Parameters.AddWithValue("@courseId", entity.CourseId);
            result.Parameters.AddWithValue("@userId", entity.UserId);
            result.Parameters.AddWithValue("@status", entity.Status);

            return result;
        }

        public static SqlCommand CreateUpdateUserCourseSqlCommand(UserCourseEntity entity)
        {
            var result = new SqlCommand("[sp_UpdateUserCourse]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            result.Parameters.AddWithValue("@courseId", entity.CourseId);
            result.Parameters.AddWithValue("@userId", entity.UserId);
            result.Parameters.AddWithValue("@status", entity.Status);
            result.Parameters.AddWithValue("@dateCompleted", entity.DateCompleted);

            return result;
        }

        public static SqlCommand CreateDeleteUserCourseSqlCommand(Guid courseId, string userId)
        {
            var result = new SqlCommand("[sp_DeleteUserCourse]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            result.Parameters.AddWithValue("@courseId", courseId);
            result.Parameters.AddWithValue("@userId", userId);

            return result;
        }
    }
}
