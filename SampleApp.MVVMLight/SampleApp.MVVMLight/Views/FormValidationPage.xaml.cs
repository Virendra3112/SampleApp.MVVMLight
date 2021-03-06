using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormValidationPage : ContentPage
    {
        private FormValidationPageModel FormValidationPageModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FormValidationPageModel>();
            }
        }
        public FormValidationPage()
        {
            InitializeComponent();
            BindingContext = FormValidationPageModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}