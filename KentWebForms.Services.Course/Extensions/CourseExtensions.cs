namespace KentWebForms.Services.Faculty.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using KentWebForms.Infrastructure.Entities.Courses;
    using KentWebForms.Infrastructure.Models.Courses;

    public static class CourseExtensions
    {
        public static IEnumerable<Course> AsModel(this IEnumerable<CourseEntity> entities)
        {
            var result = Enumerable.Empty<Course>();
            if (entities != null)
            {
                result = entities.Select(entity => entity.AsModel());
            }

            return result;
        }

        public static Course AsModel(this CourseEntity entity)
        {
            var result = new Course
            {
                Id = entity.CourseId,
                Title = entity.CourseTitle,
                Category = entity.CourseCategory,
                DisplayImgBase64 = entity.CourseDisplayImg,
                CoverImgBase64 = entity.CourseCoverImg,
                Hidden = entity.Hidden,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated
            };

            return result;
        }
    }
}
