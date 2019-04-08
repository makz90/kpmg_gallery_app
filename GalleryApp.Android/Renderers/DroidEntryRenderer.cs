using System.ComponentModel;
using Android.Content;
using GalleryApp.Droid.Renderers;
using GalleryApp.Pages.Base;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AllCapsEntry), typeof(DroidEntryRenderer))]
namespace GalleryApp.Droid.Renderers
{
    public class DroidEntryRenderer : EntryRenderer
    {
        public DroidEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element is AllCapsEntry myEntry && myEntry.HasAllCapitals)
            {
                Control.Text = Element.Text.ToUpper();
            }
        }
    }
}