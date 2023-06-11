CREATE PROCEDURE [dbo].[sp_GetUserCourses]
    @userId NVARCHAR(128)
AS
	SELECT C.[CourseId]
      ,C.[CourseTitle]
      ,C.[CourseCategory]
      ,C.[CourseDisplayImg]
      ,C.[CourseState]
      ,C.[DateCreated]
      ,C.[DateUpdated]
      ,UC.[UserId]
      ,UC.[Status]
  FROM [dbo].[Courses] as C
  FULL OUTER JOIN [dbo].[UserCourses] as UC
  ON C.[CourseId] = UC.[CourseId]
  ORDER BY [DateUpdated], [DateCreated]
RETURN 0
