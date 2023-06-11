namespace KentWebForms.Services.Faculty.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using KentWebForms.Infrastructure.Entities.Courses;
    using KentWebForms.Infrastructure.Models.Courses;

    public static class CourseExtensions
    {
        public static UserCourseEntity AsEntity(this UserCourse entity)
        {
            var result = new UserCourseEntity
            {
                CourseId = entity.Id,
                CourseTitle = entity.Title,
                CourseCategory = entity.Category,
                CourseDescription = entity.Description,
                CourseDisplayImg = entity.DisplayImgBase64,
                CourseCoverImg = entity.CoverImgBase64,
                CourseState = entity.State,
                DateEnrolled = entity.DateEnrolled,
                DateCompleted = entity.DateCompleted,
                UserId = entity.UserId,
                Status = entity.Status
            };

            return result;
        }

        public static IEnumerable<UserCourse> AsModel(this IEnumerable<UserCourseEntity> entities)
        {
            var result = Enumerable.Empty<UserCourse>();
            if (entities != null)
            {
                result = entities.Select(entity => entity.AsModel());
            }

            return result;
        }

        public static UserCourse AsModel(this UserCourseEntity entity)
        {
            var result = new UserCourse
            {
                Id = entity.CourseId,
                Title = entity.CourseTitle,
                Category = entity.CourseCategory,
                Description = entity.CourseDescription,
                DisplayImgBase64 = entity.CourseDisplayImg,
                CoverImgBase64 = entity.CourseCoverImg,
                State = entity.CourseState,
                DateEnrolled = entity.DateEnrolled,
                DateCompleted = entity.DateCompleted,
                UserId = entity.UserId,
                Status = entity.Status
            };

            return result;
        }
    }
}
