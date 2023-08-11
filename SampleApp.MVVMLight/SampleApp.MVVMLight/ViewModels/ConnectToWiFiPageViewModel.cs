using SampleApp.MVVMLight.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICommand GetAvailableNetworksCommand { get; set; }
        public ICommand WifiItemSelectedCommand { get; set; }
        public ConnectToWiFiPageViewModel()
        {
            GetAvailableNetworksCommand = new Command(() => GetAvailableNetworksAsync());

            WifiItemSelectedCommand = new Command(OnItemSelected);
            IsPopupVisible = false;

            GetAvailableNetworksCommand.Execute(null);
        }


        private void GetAvailableNetworksAsync()
        {
            try
            {
                Device.StartTimer(new TimeSpan(0, 0, 60), () =>
                {
                    // do something every 60 seconds
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        IEnumerable<string> _wifiService = null;
                        _wifiService = await DependencyService.Get<IWifiConnector>()
                         .GetAvailableNetworksAsync2();

                        WifiList = new ObservableCollection<string>();
                        foreach (var item in _wifiService)
                        {
                            if (item != null)
                                WifiList.Add(item);
                        }
                    });
                    return true; // runs again, or false to stop
                });



                //var wifiConnector = DependencyService.Get<IWifiConnector>();

                //var result = await wifiConnector.GetAvailableNetworksAsync2();

                //if (result != null)
                //{
                //    WifiList = new ObservableCollection<string>();
                //    foreach (var item in result)
                //    {
                //        if (item != null)
                //            WifiList.Add(item);
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
        }


        private void OnItemSelected(object obj)
        {
            try
            {
                var data = obj as string;


            }
            catch (Exception ex)
            {

            }
        }

        private void ConnectToWifi(string ssid, string password)
        {
            try
            {
                var wifiConnector = Xamarin.Forms.DependencyService.Get<IWifiConnector>();

                if (!string.IsNullOrEmpty(ssid) && !string.IsNullOrEmpty(password))
                {
                    wifiConnector.ConnectToWifi(ssid, password);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
