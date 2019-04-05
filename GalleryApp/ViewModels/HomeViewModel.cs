using System.Windows.Input;
using GalleryApp.Extensions;
using GalleryApp.Models;
using GalleryApp.Services.Rest.Contracts;
using GalleryApp.ViewModels.Base;
using Xamarin.Forms;

namespace GalleryApp.ViewModels
{
    public class HomeViewModel : BaseViewModel<string>, IRootViewModel
    {
        private readonly IPhotosService _photosService;

        public HomeViewModel(IPhotosService photosService)
        {
            _photosService = photosService;
        }
        
        public ExtendedObservableCollection<PhotoPresentation> PhotosCollection { get; } = new ExtendedObservableCollection<PhotoPresentation>();

        public ICommand NavigateToPhotoDetailsCommand => new Command<PhotoPresentation>(p =>
            NavigationService.NavigateTo<PhotoDetailsViewModel, PhotoPresentation>(p));
        
        public override async void Prepare(string parameter)
        {
            base.Prepare(parameter);

            IsBusy = true;
            var photosResponse = await _photosService.GetPhotos();
            IsBusy = false;
            
            if (photosResponse.IsSuccess)
            {
                PhotosCollection.AddRange(photosResponse.Results);
            }
        }
    }
}