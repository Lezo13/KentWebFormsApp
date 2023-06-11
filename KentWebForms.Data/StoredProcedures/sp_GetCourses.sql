CREATE PROCEDURE [dbo].[sp_GetCourses]
AS
	SELECT C.[CourseId]
      ,C.[CourseTitle]
      ,C.[CourseCategory]
      ,C.[CourseDisplayImg]
      ,C.[CourseState]
      ,C.[DateCreated]
      ,C.[DateUpdated]
      ,(SELECT COUNT(*) FROM [UserCourses] as UC WHERE C.[CourseId] = UC.[CourseId]) [TotalEnrolled]
    FROM [dbo].[Courses] as C
    ORDER BY [DateUpdated], [DateCreated]
RETURN 0
