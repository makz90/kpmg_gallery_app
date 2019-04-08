using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GalleryApp.Configuration.Ioc.Contracts;
using GalleryApp.Pages.Base;
using GalleryApp.ViewModels.Base;
using Xamarin.Forms;

namespace GalleryApp.Services
{
	public class FormsNavigationService : INavigationService
    {
	    private readonly IViewAndViewModelResolver _viewAndViewModelResolver;
        private bool _navigationInProgress;

        public FormsNavigationService(IViewAndViewModelResolver viewAndViewModelResolver)
	    {
		    _viewAndViewModelResolver = viewAndViewModelResolver;
        }
	    
        private INavigation FormsNavigation => Application.Current.MainPage.Navigation;
        
        public async Task Close<TViewModel>(TViewModel viewModel) where TViewModel : IBaseViewModel
        {
            for (var i = FormsNavigation.NavigationStack.Count - 1; i >= 0; i--)
            {
                var page = FormsNavigation.NavigationStack[i];
                if (page is IBasePage basePage)
                {
                    if (basePage.ViewModel is TViewModel)
                    {
                        if (i == FormsNavigation.NavigationStack.Count)
                            await FormsNavigation.PopAsync(true);
                        else
                            FormsNavigation.RemovePage(page);

                        return;
                    }
                }
                else if (page is NavigationPage naviPage)
                {
                    if ((naviPage.CurrentPage.BindingContext) is TViewModel)
                    {
                        await FormsNavigation.PopAsync(true);
                        return;
                    }
                }
            }
        }

        public async Task Close()
        {
	        if (Application.Current.MainPage is NavigationPage orientationPage)
	        {
		        if (FormsNavigation.ModalStack.Count > 0)
			        await FormsNavigation.PopModalAsync();
                else
                {
                    await FormsNavigation.PopAsync();
                }
	        }
	        else
		        await FormsNavigation.PopAsync();
		}

	    public async Task CloseToRoot()
	    {
		    if (Application.Current.MainPage is NavigationPage naviPage)
		    {
			    await naviPage.PopToRootAsync();
		    }
	    }

	    public async Task NavigateTo<T, TParameter>(TParameter parameter) where T : class, IBaseViewModel<TParameter> where TParameter : class
        {
            if (_navigationInProgress) return;
            _navigationInProgress = true;
            IBasePage page = null;

            try
            {
                var resolved = _viewAndViewModelResolver.ResolveViewModelAndPage<T, TParameter>();
                resolved.Item1.Prepare(parameter);
                page = resolved.Item2;

                await PushPage(page);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                try
                {
                    await PushPage(page);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }
            finally
            {
                _navigationInProgress = false;
            }
        }

        private async Task PushPage(IBasePage page)        
        {
	        if (page.ViewModel is IRootViewModel)
	        {
				Application.Current.MainPage = GetPageBasedOnConfiguration(page);
		        return;
	        }

	        if (Application.Current.MainPage is NavigationPage naviPage)
	        {
                var disposingView = naviPage.CurrentPage.BindingContext ??
                                    ((NavigationPage) naviPage.CurrentPage).CurrentPage.BindingContext;

                ((IDisposingView)disposingView).IsDisposing = false;
                await FormsNavigation.PushAsync(GetPageBasedOnConfiguration(page));
	        }
	        else
		        await FormsNavigation.PushAsync(GetPageBasedOnConfiguration(page));
        }

        public async Task NavigateTo(Type viewModelType, object parameter)
        {
            var viewModel = _viewAndViewModelResolver.ResolveViewModel(viewModelType);
            var page = (IBasePage)_viewAndViewModelResolver.GetFormsPage(viewModelType);
            page.ViewModel = viewModel;
			((IPreparableViewModel)viewModel).Prepare(parameter);
            await PushPage(page);
        }

        public async Task NavigateModalTo<T, TParameter>(TParameter parameter) where T : class, IBaseViewModel<TParameter> where TParameter : class 
        {
            var resolved = _viewAndViewModelResolver.ResolveViewModelAndPage<T, TParameter>();
            resolved.Item1.Prepare(parameter);
            await FormsNavigation.PushModalAsync(GetPageBasedOnConfiguration(resolved.Item2));
        }

        public static Page GetPageBasedOnConfiguration(IBasePage page)
        {
            if (!page.IsNavigationPage) return page as Page;

            var naviPage = new NavigationPage(page as Page);
            return naviPage;

        }
    }
}