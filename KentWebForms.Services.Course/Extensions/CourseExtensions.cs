namespace KentWebForms.Services.Faculty.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using KentWebForms.Infrastructure.Entities.Courses;
    using KentWebForms.Infrastructure.Models.Courses;

    public static class CourseExtensions
    {
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
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
                UserId = entity.UserId,
                Status = entity.Status
            };

            return result;
        }
    }
}
