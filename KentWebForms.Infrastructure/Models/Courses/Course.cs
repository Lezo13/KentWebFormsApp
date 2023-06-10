namespace KentWebForms.Infrastructure.Models.Courses
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Course
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string DisplayImgBase64 { get; set; }

        [DataMember]
        public string CoverImgBase64 { get; set; }

        [DataMember]
        public bool Hidden { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public DateTime DateUpdated { get; set; }
    }
}
