namespace KentWebForms.Infrastructure.Models.Courses
{
    using System;

    public class CourseUser
    {
        public Guid CourseId { get; set; }

        public string Status { get; set; }

        public DateTime DateEnrolled { get; set; }

        public DateTime DateCompleted { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
