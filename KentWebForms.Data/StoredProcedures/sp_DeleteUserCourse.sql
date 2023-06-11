CREATE PROCEDURE [dbo].[sp_DeleteUserCourse]
    @userId NVARCHAR(128),
    @courseId UNIQUEIDENTIFIER
AS
    DELETE FROM [dbo].[UserCourses]
    WHERE [CourseId] = @courseId AND [UserId] = @userId
RETURN 0
