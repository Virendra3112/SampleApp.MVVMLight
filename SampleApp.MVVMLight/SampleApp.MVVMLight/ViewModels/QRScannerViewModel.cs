using Acr.UserDialogs;
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
    }
}
