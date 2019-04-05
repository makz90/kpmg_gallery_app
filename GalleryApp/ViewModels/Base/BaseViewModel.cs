using System.Windows.Input;
using GalleryApp.Services;
using Xamarin.Forms;

namespace GalleryApp.ViewModels.Base
{
    public interface IRootViewModel
    {
    }

    public abstract class BaseViewModel : Bindable, IBaseViewModel, INavigationServiceInjector, IDisposingView
	{
		private bool _isBusy;
		private string _title = string.Empty;
		private bool _alreadyDisappeared;

		public INavigationService NavigationService { get; private set; }

		public ICommand CloseCommand => new Command(Close);

		protected virtual void Close()
		{
			if (_alreadyDisappeared) return;
			NavigationService.Close();
		}

		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

		public virtual void OnAppearing()
		{
			((IDisposingView)this).IsDisposing = true;
			_alreadyDisappeared = false;
		}

		public virtual void OnDisappearing()
		{
			_alreadyDisappeared = true;
		}

		void INavigationServiceInjector.Inject(INavigationService navigationService)
		{
			NavigationService = navigationService;
		}

		bool IDisposingView.IsDisposing { get; set; }

	}

	public interface IDisposingView
	{
		bool IsDisposing { get; set; }
	}

	public interface INavigationServiceInjector
	{
		void Inject(INavigationService navigationService);
	}

	public abstract class BaseViewModel<TParameter> : BaseViewModel, IBaseViewModel<TParameter>, IPreparableViewModel
	{
		public virtual void Prepare(TParameter parameter)
		{
		}

		void IPreparableViewModel.Prepare(object parameter)
		{
			Prepare((TParameter) parameter);
		}
	}
}