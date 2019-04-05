using Xamarin.Forms.Xaml;
using Autofac;
using DLToolkit.Forms.Controls;
using GalleryApp.Configuration;
using GalleryApp.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GalleryApp
{
    public partial class App : BaseFormsApp
    {
        public App(IContainer container) : base(container)
        {
            InitializeComponent();
            FlowListView.Init();
            ResolveAppStart<HomeViewModel, string>();
        }
    }
}