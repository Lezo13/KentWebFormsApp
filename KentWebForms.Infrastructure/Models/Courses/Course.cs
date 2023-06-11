namespace KentWebForms.Infrastructure.Models.Courses
{
    using System;

    public class Course
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string DisplayImgBase64 { get; set; }

        public string CoverImgBase64 { get; set; }

        public string State { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public int TotalEnrolled { get; set; }
    }
}
