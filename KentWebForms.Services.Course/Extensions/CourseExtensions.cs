namespace KentWebForms.Services.Course.Extensions
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
                Description = entity.CourseDescription,
                DisplayImgBase64 = entity.CourseDisplayImg,
                CoverImgBase64 = entity.CourseCoverImg,
                State = entity.CourseState,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
                TotalEnrolled = entity.TotalEnrolled
            };

            return result;
        }

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
                CourseDateCreated = entity.CourseDateCreated,
                CourseDateUpdated = entity.CourseDateUpdated,
                UserId = entity.UserId,
                Status = entity.Status,
                DateEnrolled = entity.DateEnrolled,
                DateCompleted = entity.DateCompleted
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
                CourseDateCreated = entity.CourseDateCreated,
                CourseDateUpdated = entity.CourseDateUpdated,
                UserId = entity.UserId,
                Status = entity.Status,
                DateEnrolled = entity.DateEnrolled,
                DateCompleted = entity.DateCompleted,
            };

            return result;
        }

        public static IEnumerable<CourseUser> AsModel(this IEnumerable<CourseUserEntity> entities)
        {
            var result = Enumerable.Empty<CourseUser>();
            if (entities != null)
            {
                result = entities.Select(entity => entity.AsModel());
            }

            return result;
        }

        public static CourseUser AsModel(this CourseUserEntity entity)
        {
            var result = new CourseUser
            {
                CourseId = entity.CourseId,
                Status = entity.Status,
                DateCompleted = entity.DateCompleted,
                DateEnrolled = entity.DateEnrolled,
                UserId = entity.UserId,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName  = entity.LastName,
                UserName = entity.UserName
            };

            return result;
        }
    }
}
