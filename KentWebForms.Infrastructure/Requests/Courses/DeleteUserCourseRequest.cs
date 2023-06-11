using System;

namespace KentWebForms.Infrastructure.Requests.Courses
{
    public class DeleteUserCourseRequest
    {
        public string UserId { get; set; }

        public Guid CourseId { get; set; }
    }
}
