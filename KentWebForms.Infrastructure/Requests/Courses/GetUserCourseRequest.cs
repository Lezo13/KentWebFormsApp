﻿using System;

namespace KentWebForms.Infrastructure.Requests.Courses
{
    public class GetUserCourseRequest
    {
        public Guid CourseId { get; set; }

        public string UserId { get; set; }
    }
}
