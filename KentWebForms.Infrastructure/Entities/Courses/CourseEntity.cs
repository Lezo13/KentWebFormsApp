namespace KentWebForms.Infrastructure.Entities.Courses
{
    using System;

    public class CourseEntity
    {
        public Guid CourseId { get; set; }

        public string CourseTitle { get; set; }

        public string CourseCategory { get; set; }

        public string CourseDescription { get; set; }

        public string CourseDisplayImg { get; set; }

        public string CourseCoverImg { get; set; }

        public string CourseState { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int TotalEnrolled { get; set; }
    }
}
