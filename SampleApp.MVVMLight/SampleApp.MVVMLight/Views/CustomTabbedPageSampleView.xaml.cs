using CommonServiceLocator;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTabbedPageSampleView : ExtendedTabbedPage
    {
        private CustomTabbedPageSampleViewModel CustomTabbedPageSampleViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomTabbedPageSampleViewModel>();
            }
        }
        public CustomTabbedPageSampleView()
        {
            InitializeComponent();
            BindingContext = CustomTabbedPageSampleViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}