using System.Collections.Generic;
using Autofac;
using Autofac.Features.ResolveAnything;
using GalleryApp.Configuration.Ioc.Modules;

namespace GalleryApp.Configuration.Ioc
{
	public abstract class ContainerDependencyModulesProvider
	{
		protected abstract IEnumerable<Module> GetPlatformSpecificModules();

		public virtual ContainerBuilder RegisterModules()
		{
			var builder = new ContainerBuilder();
			builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

			builder.RegisterModule<PortableDepenedenciesModule>();
			builder.RegisterModule<ViewModelsModule>();
			builder.RegisterModule<ViewsModule>();

			foreach (var platformSpecificModule in GetPlatformSpecificModules())
				builder.RegisterModule(platformSpecificModule);

			return builder;
		}
	}
}