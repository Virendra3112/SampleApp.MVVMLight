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
        private static ViewModelLocator _viewModelLocator;

        public App()
        {
            try
            {
                InitializeComponent();

                if (!ServiceLocator.IsLocationProviderSet)
                    ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(Locator.Container));


                MainPage = new NavigationPage(new DasboardView());
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
