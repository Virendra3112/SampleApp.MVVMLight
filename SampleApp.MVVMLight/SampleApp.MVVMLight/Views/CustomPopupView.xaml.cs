using CommonServiceLocator;
using Rg.Plugins.Popup.Pages;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPopupView : PopupPage
    {
        private CustomPopupViewModel CustomPopupViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomPopupViewModel>();
            }
        }
        public CustomPopupView()
        {
            InitializeComponent();
            BindingContext = CustomPopupViewModel;
        }
    }
}