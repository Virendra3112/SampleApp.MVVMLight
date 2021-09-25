using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.ViewModels
{
    public class QRScannerViewModel : BaseViewModel
    {
        private bool isScanning = true;

        public bool IsScanning
        {
            get => isScanning;
            set
            {
                isScanning = value;
                OnPropertyChanged();
            }
        }

        public Command<string> ResultCommand => new Command<string>(async (result) =>
        {
            if (IsScanning)
            {
                IsScanning = false;

                UserDialogs.Instance.Alert("QR scanned: " + result, "OK");

                //await DisplayAlert("QR scanned", result, "Ok");

                IsScanning = true;
            }
        });


        public QRScannerViewModel()
        {

        }

        private async void CheckPermission()
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.Camera>();

                if (status != PermissionStatus.Granted)
                {
                    IsScanning = false;

                    await UserDialogs.Instance.AlertAsync("Error",
                        "Camera permission is required for QR scanner.", "OK");
                }
                else
                {
                    IsScanning = true;
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
