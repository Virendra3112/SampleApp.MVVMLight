using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationDrawerPage : ContentPage
    {
        private NavigationDrawerPageViewModel NavigationDrawerPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationDrawerPageViewModel>();
            }
        }
        public NavigationDrawerPage()
        {
            InitializeComponent();
            BindingContext = NavigationDrawerPageViewModel;
        }
    }
}