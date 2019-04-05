using Autofac;
using GalleryApp.Configuration;

namespace GalleryApp.iOS.Ioc
{
    public static class Bootstrapper
    {
        public static IContainer Init()
        {
            CoreBootstrapper.Init();
            var builder = new iOSContainerDependencyInjectionConfig().RegisterModules();
            return builder.Build();
        }
    }
}