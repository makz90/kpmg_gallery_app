using GalleryApp.Pages.Base;
using GalleryApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : BasePage<HomeViewModel, string>
	{
		public HomePage ()
		{
			InitializeComponent ();
		}
	}
}