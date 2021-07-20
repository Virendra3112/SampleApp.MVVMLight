using Autofac.Extras.CommonServiceLocator;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using CommonServiceLocator;
using SampleApp.MVVMLight.Helpers;
using SampleApp.MVVMLight.Views;
using System;
using System.Collections.Generic;
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

                //Remove this method to stop OneSignal Debugging  
                OneSignal.Current.SetLogLevel(LOG_LEVEL.VERBOSE, LOG_LEVEL.NONE);

                OneSignal.Current.StartInit("YOUR_ONESIGNAL_APP_ID") //todo add AppId here
                .Settings(new Dictionary<string, bool>() {
                                { IOSSettings.kOSSettingsKeyAutoPrompt, false },
                                { IOSSettings.kOSSettingsKeyInAppLaunchURL, false } })
                .InFocusDisplaying(OSInFocusDisplayOption.Notification)
                .EndInit();

                // The promptForPushNotificationsWithUserResponse function will show the iOS push notification prompt. We recommend removing the following code and instead using an In-App Message to prompt for notification permission (See step 7)
                OneSignal.Current.RegisterForPushNotifications();
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
