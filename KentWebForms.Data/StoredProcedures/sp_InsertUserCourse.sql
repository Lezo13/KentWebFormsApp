CREATE PROCEDURE [dbo].[sp_InsertUserCourse]
    @userId NVARCHAR(128),
    @courseId UNIQUEIDENTIFIER,
    @status NVARCHAR(500)
AS
    INSERT INTO [dbo].[UserCourses]
        ([CourseId]
        ,[UserId]
        ,[Status])
    VALUES
        (@courseId
        ,@userId
        ,@status)
RETURN 0
