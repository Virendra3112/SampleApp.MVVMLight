using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomSheetDemoView : ContentPage
    {
        private BottomSheetDemoViewModel BottomSheetDemoViewVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BottomSheetDemoViewModel>();
            }
        }
        public BottomSheetDemoView()
        {
            InitializeComponent();
            BindingContext = BottomSheetDemoViewVM;
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
           //await Application.Current.MainPage.Navigation.PushModalAsync(new OTPPage());
                //ShowPopup(new CustomPopUp());

            await Sheet.OpenSheet();
        }
    }
}