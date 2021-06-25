using AutoGallery.Controllers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace AutoGallery
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<HomeController>(new InjectionConstructor());
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}