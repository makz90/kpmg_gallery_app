using Autofac;
using GalleryApp.Configuration;

namespace GalleryApp.Droid.Ioc
{
    public static class Bootstrapper
    {
        public static IContainer Init()
        {
            CoreBootstrapper.Init();
            var builder = new DroidContainerDependencyInjectionConfig().RegisterModules();
            return builder.Build();
        }
    }
}