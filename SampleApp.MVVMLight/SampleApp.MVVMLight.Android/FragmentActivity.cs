using System;
using System.Collections.Generic;
using ZXing.Mobile;
using Android.OS;
using Android.App;
using Android.Widget;
using Android.Content.PM;
using System.Threading.Tasks;

namespace SampleApp.MVVMLight.Droid
{
    [Activity(Label = "ZXing.Net.Mobile", Theme = "@android:style/Theme.Holo.Light", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
    public class FragmentActivity : global::Android.Support.V4.App.FragmentActivity
    {
        ZXingScannerFragment scanFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FragmentActivity);
        }

        protected override void OnResume()
        {
            base.OnResume();

            var needsPermissionRequest = ZXing.Net.Mobile.Android.PermissionsHandler.NeedsPermissionRequest(this);

            if (needsPermissionRequest)
                ZXing.Net.Mobile.Android.PermissionsHandler.RequestPermissionsAsync(this);

            if (scanFragment == null)
            {
                scanFragment = new ZXingScannerFragment();

                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.fragment_container, scanFragment)
                    .Commit();
            }

            //if (!needsPermissionRequest)
            ScanAsync();
            //scan();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnPause()
        {
            scanFragment?.StopScanning();

            base.OnPause();
        }

        void scan()
        {
            var opts = new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<ZXing.BarcodeFormat> {
                    ZXing.BarcodeFormat.QR_CODE,
                },
                CameraResolutionSelector = availableResolutions =>
                {
                    foreach (var ar in availableResolutions)
                    {
                        Console.WriteLine("Resolution: " + ar.Width + "x" + ar.Height);
                    }
                    return null;
                }
            };

            scanFragment.StartScanning(result =>
            {

                // Null result means scanning was cancelled
                if (result == null || string.IsNullOrEmpty(result.Text))
                {
                    Toast.MakeText(this, "Scanning Cancelled", ToastLength.Long).Show();
                    return;
                }

                // Otherwise, proceed with result
                RunOnUiThread(() => Toast.MakeText(this, "Scanned: " + result.Text, ToastLength.Short).Show());
            }, opts);
        }

        public async Task ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan the QR Code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(optionsCustom);

            Toast.MakeText(this, "***" + scanResult.Text, ToastLength.Long).Show();
        }
    }
}