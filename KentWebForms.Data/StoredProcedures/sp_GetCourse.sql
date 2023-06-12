CREATE PROCEDURE [dbo].[sp_GetCourse]
    @courseId UNIQUEIDENTIFIER
AS
    SELECT C.[CourseId]
        ,C.[CourseTitle]
        ,C.[CourseCategory]
        ,C.[CourseDescription]
        ,C.[CourseDisplayImg]
        ,C.[CourseCoverImg]
        ,C.[CourseState]
        ,C.[DateCreated]
        ,C.[DateUpdated]
        ,(SELECT COUNT(*) FROM [UserCourses] as UC WHERE C.[CourseId] = UC.[CourseId]) [TotalEnrolled]
    FROM [dbo].[Courses] as C
    LEFT JOIN [dbo].[UserCourses] as UC
    ON C.[CourseId] = UC.[CourseId]
    WHERE C.CourseId = @courseId
RETURN 0
