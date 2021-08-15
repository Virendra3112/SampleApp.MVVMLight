using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OTPPage : ContentPage
    {
        private OTPPageViewModel OTPPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OTPPageViewModel>();
            }
        }
        public OTPPage()
        {
            InitializeComponent();
            BindingContext = OTPPageViewModel;
        }
    }
}