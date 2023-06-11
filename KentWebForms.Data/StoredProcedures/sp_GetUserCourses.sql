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
    LEFT JOIN [dbo].[UserCourses] as UC
    ON C.[CourseId] = UC.[CourseId] AND (UC.[UserId] IS NULL OR UC.UserId = @userId)
    ORDER BY [DateUpdated], [DateCreated]
RETURN 0
