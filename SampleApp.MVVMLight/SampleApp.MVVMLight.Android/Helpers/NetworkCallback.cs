using Android.App;
using Android.Content;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApp.MVVMLight.Droid.Helpers
{
    public class NetworkCallback : ConnectivityManager.NetworkCallback
    {
        public NetworkCallback(int flags) //: base(flags)
        {
        }

        public override void OnCapabilitiesChanged(Network network, NetworkCapabilities networkCapabilities)
        {
            base.OnCapabilitiesChanged(network, networkCapabilities);
            WifiInfo wifiInfo = (WifiInfo)networkCapabilities.TransportInfo;

            if (wifiInfo != null)
            {
                string ssid = wifiInfo.SSID.Trim(new char[] { '"', '\"' });
                string bssid = wifiInfo.BSSID;
            }
        }
    }
}