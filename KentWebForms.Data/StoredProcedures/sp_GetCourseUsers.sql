CREATE PROCEDURE [dbo].[sp_GetCourseUsers]
    @courseId UNIQUEIDENTIFIER
AS
    SELECT 
	     UC.[CourseId]
        ,UC.[Status]
        ,UC.[DateEnrolled]
        ,UC.[DateCompleted]
	    ,UC.[UserId]
	    ,U.[FirstName]
        ,U.[LastName]
        ,U.[Email]
        ,U.[UserName]
    FROM [dbo].[Users]  as U 
    INNER JOIN [dbo].[UserCourses] as UC
    ON UC.[UserId] = U.[Id]
    WHERE UC.[CourseId] = @courseId
RETURN 0
