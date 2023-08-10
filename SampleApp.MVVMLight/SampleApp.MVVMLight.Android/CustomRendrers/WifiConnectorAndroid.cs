using Android.Content;
using Android.Net;
using Android.Net.Wifi;
using SampleApp.MVVMLight.Droid.CustomRendrers;
using SampleApp.MVVMLight.Droid.Helpers;
using SampleApp.MVVMLight.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(WifiConnectorAndroid))]
namespace SampleApp.MVVMLight.Droid.CustomRendrers
{
    public class WifiConnectorAndroid : IWifiConnector
    {
        public void ConnectToWifi(string ssid, string password)
        {
            //var formattedSsid = $"\"{ssid}\"";
            //var formattedPassword = $"\"{password}\"";

            //var wifiConfig = new WifiConfiguration
            //{
            //    Ssid = formattedSsid,
            //    PreSharedKey = formattedPassword
            //};

            //var wifiManager = (WifiManager)Android.App.Application.Context
            //            .GetSystemService(Context.WifiService);

            //var addNetwork = wifiManager.AddNetwork(wifiConfig);


            WifiNetworkSpecifier wifiNetworkSpecifier = new WifiNetworkSpecifier.Builder()
            .SetSsid(ssid)
            .SetWpa2Passphrase(password)
            .Build();
            NetworkRequest networkRequest = new NetworkRequest.Builder()
                        .AddTransportType(Android.Net.TransportType.Wifi)// NetworkCapabilities.TransportWifi)
                        .SetNetworkSpecifier(wifiNetworkSpecifier)
                        .Build();
            ConnectivityManager connectivityManager =
                (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            connectivityManager.RequestNetwork(networkRequest, new ConnectivityManager.NetworkCallback());
        }

        public async Task<IEnumerable<string>> GetAvailableNetworksAsync()
        {
            IEnumerable<string> availableNetworks = null;

            // Get a handle to the Wifi
            var wifiMgr = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
            var wifiReceiver = new WifiReceiver(wifiMgr);

            await Task.Run(() =>
            {
                // Start a scan and register the Broadcast receiver to get the list of Wifi Networks
                Android.App.Application.Context.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
                availableNetworks = wifiReceiver.Scan();
            });

            return availableNetworks;
        }


        private Context context = null;

        public WifiConnectorAndroid()
        {
            this.context = Android.App.Application.Context;
        }

        public async Task<IEnumerable<string>> GetAvailableNetworksAsync2()
        {
            IEnumerable<string> availableNetworks = null;

            // Get a handle to the Wifi
            var wifiMgr = (WifiManager)context.GetSystemService(Context.WifiService);
            var wifiReceiver = new WifiReceiver(wifiMgr);

            await Task.Run(() =>
            {
                // Start a scan and register the Broadcast receiver to get the list of Wifi Networks
                context.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
                availableNetworks = wifiReceiver.Scan();
            });

            return availableNetworks;
        }
    }
}