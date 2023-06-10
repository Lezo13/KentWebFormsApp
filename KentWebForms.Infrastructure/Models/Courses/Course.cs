using System;

namespace KentWebForms.Infrastructure.Models.Courses
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string DisplayImgBase64 { get; set; }

        public string CoverImgBase64 { get; set; }
    }
}
