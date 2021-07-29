using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepbarSampleView : ContentPage
    {
        private StepbarSampleViewModel StepbarSampleViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StepbarSampleViewModel>();
            }
        }
        public StepbarSampleView()
        {
            InitializeComponent();
            BindingContext = StepbarSampleViewModel;
        }
    }
}