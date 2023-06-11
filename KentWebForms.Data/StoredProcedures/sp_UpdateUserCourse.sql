CREATE PROCEDURE [dbo].[sp_UpdateUserCourse]
    @userId NVARCHAR(128),
    @courseId UNIQUEIDENTIFIER,
    @status NVARCHAR(500),
    @dateCompleted DATETIME = NULL
AS
    UPDATE [dbo].[UserCourses]
       SET [Status] = @status,
           [DateCompleted] = @dateCompleted
     WHERE [CourseId] = @courseId AND [UserId] = @userId
RETURN 0
