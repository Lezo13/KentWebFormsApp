CREATE PROCEDURE [dbo].[sp_GetUserCourse]
    @courseId UNIQUEIDENTIFIER,
    @userId NVARCHAR(128)
AS
    SELECT C.[CourseId]
        ,C.[CourseTitle]
        ,C.[CourseCategory]
        ,C.[CourseDescription]
        ,C.[CourseDisplayImg]
        ,C.[CourseCoverImg]
        ,C.[CourseState]
        ,C.[DateCreated] [CourseDateCreated]
        ,C.[DateUpdated] [CourseDateUpdated]
        ,UC.[UserId]
        ,UC.[Status]
    FROM [dbo].[Courses] as C
    LEFT JOIN [dbo].[UserCourses] as UC
    ON C.[CourseId] = UC.[CourseId] AND UC.[UserId] = @userId
    WHERE C.CourseId = @courseId
RETURN 0
