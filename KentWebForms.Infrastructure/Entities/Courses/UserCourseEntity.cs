namespace KentWebForms.Infrastructure.Entities.Courses
{
    using System;

    public class UserCourseEntity
    {
        public Guid CourseId { get; set; }

        public string CourseTitle { get; set; }

        public string CourseCategory { get; set; }

        public string CourseDescription { get; set; }

        public string CourseDisplayImg { get; set; }

        public string CourseCoverImg { get; set; }

        public string CourseState { get; set; }

        public DateTime DateEnrolled { get; set; }

        public DateTime DateCompleted { get; set; }

        public string UserId { get; set; }

        public string Status { get; set; }
    }
}
