using GalleryApp.ViewModels.Base;
using Xamarin.Forms;

namespace GalleryApp.Pages.Base
{
    public class BasePage<TViewModel, TParameter> : ContentPage, IBasePage<TViewModel, TParameter> where TViewModel : IBaseViewModel<TParameter> where TParameter : class
    {
        private TViewModel _viewModel;

        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, IsNavigationBarVisible);
        }

        public TViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                BindingContext = _viewModel;
            }
        }

        IBaseViewModel IBasePage.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TViewModel)value;
        }

        public virtual bool IsNavigationPage => true;

        public bool IsNavigationBarVisible => true;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.OnDisappearing();
        }
    }

    public interface IBasePage<TViewModel, TParameter> : IBasePage where TViewModel : IBaseViewModel<TParameter>
    {
        TViewModel ViewModel { get; set; }
    }

    public interface IBasePage
    {
        IBaseViewModel ViewModel { get; set; }

        bool IsNavigationPage { get; }

        bool IsNavigationBarVisible { get; }
    }
}
