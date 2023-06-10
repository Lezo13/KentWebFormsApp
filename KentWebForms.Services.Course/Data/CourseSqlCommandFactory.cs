namespace KentWebForms.Services.Course.Data
{
    using System.Data;
    using System.Data.SqlClient;

    public static class CourseSqlCommandFactory
    {
        public static SqlCommand CreateGetCoursesSqlCommand()
        {
            var result = new SqlCommand("[sp_GetCourses]")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };

            return result;
        }
    }
}
