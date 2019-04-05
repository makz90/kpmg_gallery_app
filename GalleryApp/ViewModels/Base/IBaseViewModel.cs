using System;
using System.ComponentModel;
using System.Windows.Input;

namespace GalleryApp.ViewModels.Base
{
    public interface IBaseViewModel : INotifyPropertyChanged
    {
        bool IsBusy { get; set; }
        string Title { get; set; }
        void OnAppearing();
        void OnDisappearing();
        ICommand CloseCommand { get; }
    }

    public interface IPreparableViewModel
    {
        void Prepare(object parameter);
    }

    public interface IBaseViewModel<TNavigationParameter> : IBaseViewModel
    {
        void Prepare(TNavigationParameter parameter);
    }
}