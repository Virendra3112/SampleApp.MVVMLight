using Android.Content;
using Android.Net;
using Android.Net.Wifi;
using SampleApp.MVVMLight.Droid.CustomRendrers;
using SampleApp.MVVMLight.Helpers;
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
    }
}