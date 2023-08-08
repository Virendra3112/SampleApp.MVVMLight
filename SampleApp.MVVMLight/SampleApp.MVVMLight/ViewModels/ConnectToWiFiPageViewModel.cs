using SampleApp.MVVMLight.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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

        private bool _isPopupVisible;
        public bool IsPopupVisible
        {
            get { return _isPopupVisible; }
            set { _isPopupVisible = value; OnPropertyChanged(); }
        }


        private ObservableCollection<string> _wifiList;
        public ObservableCollection<string> WifiList
        {
            get
            {
                return _wifiList;
            }
            set
            {
                if (_wifiList != value)
                {
                    _wifiList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand WifiItemSelectedCommand { get; set; }
        public ConnectToWiFiPageViewModel()
        {
            WifiItemSelectedCommand = new Command(OnItemSelected);
            //ConnectToWifi();
            GetAvailableNetworksAsync();
        }

        private void OnItemSelected(object obj)
        {
            throw new NotImplementedException();
        }

        private async Task GetAvailableNetworksAsync()
        {
            try
            {
                var wifiConnector = Xamarin.Forms.DependencyService.Get<IWifiConnector>();

                var result = await wifiConnector.GetAvailableNetworksAsync();

                if (result != null)
                {
                    WifiList = new ObservableCollection<string>();
                    foreach (var item in result)
                    {
                        if (item != null)
                            WifiList.Add(item);
                    }
                }
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
