using GalleryApp.Models;
using GalleryApp.Pages.Base;
using GalleryApp.ViewModels;

namespace GalleryApp.Pages
{
    public partial class PhotoDetailsPage : BasePage<PhotoDetailsViewModel, PhotoPresentation>
    {
        public PhotoDetailsPage()
        {
            InitializeComponent();
        }

        public override bool IsNavigationPage => false;
    }
}
