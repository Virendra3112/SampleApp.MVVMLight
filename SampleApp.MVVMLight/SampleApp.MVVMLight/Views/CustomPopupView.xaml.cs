using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPopupView : PopupPage
    {
        public CustomPopupView()
        {
            InitializeComponent();
        }
    }
}