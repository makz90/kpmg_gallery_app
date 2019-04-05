using System;
using GalleryApp.Pages.Base;
using GalleryApp.ViewModels.Base;
using Xamarin.Forms;

namespace GalleryApp.Configuration.Ioc.Contracts
{
    public interface IViewAndViewModelResolver : IMasterPresenterInjecter
    {
        (TViewModel, IBasePage<TViewModel, TParameter>) ResolveViewModelAndPage<TViewModel, TParameter>()
            where TViewModel : class, IBaseViewModel<TParameter> where TParameter : class;

	    IBaseViewModel ResolveViewModel(Type viewModelType);

	    Page GetFormsPage(Type viewModelType);
    }

	public interface IMasterPresenterInjecter
	{
		void InjectMasterPresenterAction(Action presentAction);
	}
}