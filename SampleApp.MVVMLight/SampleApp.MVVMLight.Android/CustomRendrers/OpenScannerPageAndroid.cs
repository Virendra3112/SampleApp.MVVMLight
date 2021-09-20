using Android.Content;
using SampleApp.MVVMLight.Droid.CustomRendrers;
using SampleApp.MVVMLight.Helpers;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenScannerPageAndroid))]
namespace SampleApp.MVVMLight.Droid.CustomRendrers
{
    public class OpenScannerPageAndroid : IOpenScannerPage
    {
        public void OpenScanner()
        {
            try
            {
                //Android.App.Application.Context.StartActivity(typeof(FragmentActivity));

                Intent intent = new Intent();
                intent.SetClass(Android.App.Application.Context, typeof(FragmentActivity));
                intent.AddFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);

            }
            catch (Exception ex)
            {

            }
        }
    }
}