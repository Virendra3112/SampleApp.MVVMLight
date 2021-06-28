using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DasboardView : ContentPage
    {
        private DasboardViewModel DashboardViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DasboardViewModel>();
            }
        }
        public DasboardView()
        {
            InitializeComponent();
            BindingContext = DashboardViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}