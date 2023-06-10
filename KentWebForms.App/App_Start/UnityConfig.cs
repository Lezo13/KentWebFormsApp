namespace KentWebForms.App
{
    using System;
    using Unity;
    using KentWebForms.App.Injection;

    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            Infrastructure.InjectInfrastructure(container);
            CourseServices.InjectCourseServices(container);
        }
    }
}