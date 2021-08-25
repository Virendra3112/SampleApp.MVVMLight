using CommonServiceLocator;
using SampleApp.MVVMLight.CustomControls;
using SampleApp.MVVMLight.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OTPPage : ContentPage
    {
        private OTPPageViewModel OTPPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OTPPageViewModel>();
            }
        }
        public OTPPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = OTPPageViewModel;

                NotificationIconWithBadge.SetNotificationCount(6);
            }
            catch (Exception ex)
            {

            }
        }
    }
}