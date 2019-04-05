using System.Reflection;
using Autofac;
using GalleryApp.Pages.Base;
using Module = Autofac.Module;

namespace GalleryApp.Configuration.Ioc.Modules
{
	public class ViewsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			
			builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(PortableDepenedenciesModule)).Assembly)
				.AssignableTo<IBasePage>()
				.AsSelf();
		}
	}
}