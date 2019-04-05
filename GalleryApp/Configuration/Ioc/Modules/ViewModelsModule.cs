using Autofac;
using GalleryApp.Services;
using GalleryApp.ViewModels.Base;
using IntrospectionExtensions = System.Reflection.IntrospectionExtensions;

namespace GalleryApp.Configuration.Ioc.Modules
{
	public class ViewModelsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			
			builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(PortableDepenedenciesModule)).Assembly)
				.AssignableTo<IBaseViewModel>()
				.As<IBaseViewModel, BaseViewModel>()
				.AsSelf()
				.OnActivating(e => {
					var navi = e.Context.Resolve<INavigationService>();
					(e.Instance as INavigationServiceInjector)?.Inject(navi);
				});
		}
	}
}