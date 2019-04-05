using System.Collections.Generic;
using Autofac;
using GalleryApp.Configuration.Ioc;

namespace GalleryApp.iOS.Ioc
{
    internal class iOSContainerDependencyInjectionConfig : ContainerDependencyModulesProvider
    {
        protected override IEnumerable<Module> GetPlatformSpecificModules()
        {
            yield return new PlatformSpecificDependenciesModule();
        }
    }
}