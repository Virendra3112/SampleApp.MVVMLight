using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationView : ContentPage
    {
        private NotificationViewModel NotificationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NotificationViewModel>();
            }
        }
        public NotificationView()
        {
            InitializeComponent();
            BindingContext = NotificationViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NotificationViewModel.GetData();
        }
    }
}