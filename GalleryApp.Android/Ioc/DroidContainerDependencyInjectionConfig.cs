using System.Collections.Generic;
using Autofac;
using GalleryApp.Configuration.Ioc;

namespace GalleryApp.Droid.Ioc
{
    internal class DroidContainerDependencyInjectionConfig : ContainerDependencyModulesProvider
    {
        protected override IEnumerable<Module> GetPlatformSpecificModules()
        {
            yield return new PlatformSpecificDependenciesModule();
        }
    }
}