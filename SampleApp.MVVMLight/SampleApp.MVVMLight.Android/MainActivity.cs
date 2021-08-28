using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using SampleApp.MVVMLight.Droid.Helpers;
using Acr.UserDialogs;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using System;
using FFImageLoading.Forms.Platform;

namespace SampleApp.MVVMLight.Droid
{
    [Activity(Label = "SampleApp.MVVMLight", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Remove this method to stop OneSignal Debugging  
            OneSignal.Current.SetLogLevel(LOG_LEVEL.VERBOSE, LOG_LEVEL.NONE);

            OneSignal.Current.StartInit("YOUR_ONESIGNAL_APP_ID") //todo add app id here
             .InFocusDisplaying(OSInFocusDisplayOption.Notification)
             .EndInit();

            string playerId = "";

            OneSignal.Current.IdsAvailable(new Com.OneSignal.Abstractions.IdsAvailableCallback((playerID, pushToken) =>
            {
                playerId = playerID;
            }));

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            AndroidBootstrapper.Initialize();

            CachedImageRenderer.Init(true);

            UserDialogs.Init(this);

            Rg.Plugins.Popup.Popup.Init(this);

            string Value = AppHashKeyHelper.GetAppHashKey(this);

            Console.WriteLine("******** Hash " + Value);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}