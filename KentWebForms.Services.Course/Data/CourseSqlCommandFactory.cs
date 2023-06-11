namespace KentWebForms.Services.Course.Data
{
    using System.Data;
    using System.Data.SqlClient;

    public static class CourseSqlCommandFactory
    {
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

        public static SqlCommand CreateGetUserCourseSqlCommand(string courseId, string userId)
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
    }
}
