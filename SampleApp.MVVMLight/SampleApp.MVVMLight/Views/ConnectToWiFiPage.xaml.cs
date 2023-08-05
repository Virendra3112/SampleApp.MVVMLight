using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectToWiFiPage : ContentPage
    {
        private ConnectToWiFiPageViewModel ConnectToWiFiPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConnectToWiFiPageViewModel>();
            }
        }
        public ConnectToWiFiPage()
        {
            InitializeComponent();

            BindingContext = ConnectToWiFiPageViewModel;
        }

    }
}