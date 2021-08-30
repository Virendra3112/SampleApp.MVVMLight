using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePageView : ContentPage
    {
        public BasePageView()
        {
            InitializeComponent();
        }
    }
}