CREATE PROCEDURE [dbo].[sp_GetCourses]
AS
	SELECT [CourseId]
      ,[CourseTitle]
      ,[CourseCategory]
      ,[CourseDescription]
      ,[CourseDisplayImg]
      ,[CourseCoverImg]
      ,[Hidden]
      ,[DateCreated]
      ,[DateUpdated]
  FROM [dbo].[Courses]
RETURN 0
