using GalleryApp.Models;
using GalleryApp.ViewModels.Base;

namespace GalleryApp.ViewModels
{
    public class PhotoDetailsViewModel : BaseViewModel<PhotoPresentation>
    {
        private PhotoPresentation _currentPhoto;

        public PhotoPresentation CurrentPhoto
        {
            get => _currentPhoto;
            set => SetProperty(ref _currentPhoto, value);
        }

        public override void Prepare(PhotoPresentation parameter)
        {
            base.Prepare(parameter);
            CurrentPhoto = parameter;
        }
    }
}