using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using GalleryApp.Droid.Ioc;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms;

namespace GalleryApp.Droid
{
    [Activity(Label = "GalleryApp", Icon = "@drawable/icon", Theme = "@style/SplashScreenTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.SetTheme(Resource.Style.MainTheme);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            UserDialogs.Init(() => this);
            CachedImageRenderer.Init(false);
            
            var container = Bootstrapper.Init();
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App(container));
        }
    }
}