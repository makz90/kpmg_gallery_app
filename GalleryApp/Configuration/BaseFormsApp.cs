using Autofac;
using GalleryApp.Configuration.Ioc.Contracts;
using GalleryApp.ViewModels.Base;
using Xamarin.Forms;

namespace GalleryApp.Configuration
{
    public abstract class BaseFormsApp : Application
    {
	    private readonly IContainer _container;

	    protected BaseFormsApp(IContainer container)
	    {
		    _container = container;
	    }

	    protected void ResolveAppStart<TViewModel, TParameter>(TParameter parameter = null) where TViewModel : class, IBaseViewModel<TParameter> where TParameter : class
        {
            var viewResolver = _container.Resolve<IViewAndViewModelResolver>();
            var resolved = viewResolver.ResolveViewModelAndPage<TViewModel, TParameter>();
            resolved.Item1.Prepare(parameter);

            var mainPage = resolved.Item2 as Page; 
            
            if (resolved.Item2.IsNavigationPage)
                mainPage = new NavigationPage(mainPage);

            MainPage = mainPage;
        }
    }
}