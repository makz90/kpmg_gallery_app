using System;
using System.Threading.Tasks;
using GalleryApp.ViewModels.Base;

namespace GalleryApp.Services
{
    public interface INavigationService
    {
        Task Close<TVievModel>(TVievModel viewModel) where TVievModel : IBaseViewModel;

        Task Close();

        Task CloseToRoot();

        Task NavigateTo<TViewModel, TParameter>(TParameter parameter)
            where TViewModel : class, IBaseViewModel<TParameter> where TParameter : class;

        Task NavigateTo(Type viewModelType, object parameter);

        Task NavigateModalTo<TViewModel, TParameter>(TParameter parameter)
            where TViewModel : class, IBaseViewModel<TParameter> where TParameter : class;
    }
}