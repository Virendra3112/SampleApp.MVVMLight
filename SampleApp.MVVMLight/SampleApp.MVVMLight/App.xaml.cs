using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using SampleApp.MVVMLight.Helpers;
using SampleApp.MVVMLight.Views;
using System;
using Xamarin.Forms;

namespace SampleApp.MVVMLight
{
    public partial class App : Application
    {

        public static MasterDetailPage MasterDetail { get; set; }
        public static NavigationPage Navigation { get; set; }
        public App()
        {
            try
            {
                InitializeComponent();

                if (!ServiceLocator.IsLocationProviderSet)
                    ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(Locator.Container));


                //MainPage = new NavigationPage(new DasboardView());

                MasterDetail = new MasterDetailPage();
                MasterDetail.Master = new NavigationDrawerPage() { Title = " " };
                Navigation = new NavigationPage(new DasboardView())
                {
                    BarBackgroundColor = Color.FromHex("#2b2841"),
                    BarTextColor = Color.White
                };
                MasterDetail.Detail = Navigation;
                MasterDetail.MasterBehavior = MasterBehavior.Popover;
                MasterDetail.IsPresented = false;
                MainPage = MasterDetail;
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
