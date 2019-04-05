using Android.Content;
using Android.Support.V4.App;
using GalleryApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(DroidNavigationPageRenderer))]
namespace GalleryApp.Droid.Renderers
{
    public class DroidNavigationPageRenderer : NavigationPageRenderer
    {
        public DroidNavigationPageRenderer(Context context) : base(context)
        {
        }

        protected override void SetupPageTransition(FragmentTransaction transaction, bool isPush)
        {
            base.SetupPageTransition(transaction, isPush);

            if (isPush)
            {
                transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                    Resource.Animation.enter_left, Resource.Animation.exit_right);
            }
            else
            {
                transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                    Resource.Animation.enter_right, Resource.Animation.exit_left);
            }
        }
    }
}