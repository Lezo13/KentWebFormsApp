namespace KentWebForms.App.Injection
{
    using KentWebForms.Infrastructure.Helpers;
    using Unity;
    using System.Configuration;

    public static class Infrastructure
    {
        public static void InjectInfrastructure(this IUnityContainer container)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            container.RegisterInstance<ISqlHelper>(new SqlHelper(connectionString));
        }
    }
}