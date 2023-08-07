using SampleApp.MVVMLight.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.MVVMLight.ViewModels
{
    public class ConnectToWiFiPageViewModel : BaseViewModel
    {
        private string _wifiStatus;
        public string WifiStatus
        {
            get { return _wifiStatus; }
            set { _wifiStatus = value; OnPropertyChanged(); }
        }

        private string _wifiPassword;
        public string WifiPassword
        {
            get { return _wifiPassword; }
            set { _wifiPassword = value; OnPropertyChanged(); }
        }
        public ConnectToWiFiPageViewModel()
        {
            //ConnectToWifi();
            GetAvailableNetworksAsync();
        }

        private async Task GetAvailableNetworksAsync()
        {
            try
            {
                var wifiConnector = Xamarin.Forms.DependencyService.Get<IWifiConnector>();

                var result = await wifiConnector.GetAvailableNetworksAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private void ConnectToWifi()
        {
            try
            {
                var wifiConnector = Xamarin.Forms.DependencyService.Get<IWifiConnector>();

                wifiConnector.ConnectToWifi("", "");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
