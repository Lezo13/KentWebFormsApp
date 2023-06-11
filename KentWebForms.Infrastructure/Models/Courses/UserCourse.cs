namespace KentWebForms.Infrastructure.Models.Courses
{
    using System;

    public class UserCourse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string DisplayImgBase64 { get; set; }

        public string State { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string UserId { get; set; }

        public string Status { get; set; }
    }
}
