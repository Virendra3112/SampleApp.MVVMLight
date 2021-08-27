using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomFeedbackPage : PopupPage
    {
        public CustomFeedbackPage()
        {
            InitializeComponent();
            this.BackgroundColor = new Xamarin.Forms.Color(0, 0, 0, 0.80);
        }
    }
}