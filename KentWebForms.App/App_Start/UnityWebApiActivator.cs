[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KentWebForms.App.UnityWebApiActivator), nameof(KentWebForms.App.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(KentWebForms.App.UnityWebApiActivator), nameof(KentWebForms.App.UnityWebApiActivator.Shutdown))]

namespace KentWebForms.App
{
    using System.Web.Http;
    using Unity.AspNet.WebApi;

    public static class UnityWebApiActivator
    {
        public static void Start() 
        {
            var resolver = new UnityDependencyResolver(UnityConfig.Container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}