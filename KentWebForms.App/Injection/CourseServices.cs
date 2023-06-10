namespace KentWebForms.App.Injection
{
    using Unity;
    using KentWebForms.Infrastructure.Interfaces;
    using KentWebForms.Services.Course;
    using KentWebForms.Services.Course.Data;

    public static class CourseServices
    {
        public static void InjectCourseServices(this IUnityContainer container)
        {
            container.RegisterType<ICourseSqlDataGateway, CourseSqlDataGateway>();
            container.RegisterType<ICourseService, CourseService>();
        }
    }
}