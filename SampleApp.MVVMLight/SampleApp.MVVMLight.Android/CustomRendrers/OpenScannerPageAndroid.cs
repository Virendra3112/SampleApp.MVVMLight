using Android.Content;
using SampleApp.MVVMLight.Droid.CustomRendrers;
using SampleApp.MVVMLight.Helpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

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

        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan the QR Code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}