using Xamarin.Forms;

namespace GalleryApp.Pages.Base
{
    public class AllCapsEntry : Entry
    {
        public static readonly BindableProperty HasAllCapitalsProperty = BindableProperty.Create(nameof(HasAllCapitals),
            typeof(bool),
            typeof(AllCapsEntry),
            (object)false,
            BindingMode.OneWay);

        public bool HasAllCapitals
        {
            get
            {
                return (bool)this.GetValue(HasAllCapitalsProperty);
            }
            set
            {
                this.SetValue(HasAllCapitalsProperty, (object)value);
            }
        }
    }
}