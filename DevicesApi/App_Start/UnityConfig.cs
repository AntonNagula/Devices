using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using ONION.DependencyInjection;
using ONION.DependencyInjection.Moduls;
namespace DevicesApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            Register<RepositoryModul>(container);
            Register<UserContext>(container);
            
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static void Register<T>(IUnityContainer container) where T : IModul, new()
        {
            
            new T().Register(container);
        }
    }
}