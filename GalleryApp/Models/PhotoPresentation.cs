using GalleryApp.ViewModels.Base;

namespace GalleryApp.Models
{
    public class PhotoPresentation : Bindable
    {
        private int _albumId;
        private int _id;
        private string _title;
        private string _url;
        private string _thumbnailUrl;

        public int AlbumId 
        { 
            get => _albumId;
            set => SetProperty(ref _albumId, value);
        }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public string ThumbnailUrl
        {
            get => _thumbnailUrl;
            set => SetProperty(ref _thumbnailUrl, value);
        }
    }
}