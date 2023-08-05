using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleApp.MVVMLight.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApp.MVVMLight.Droid.CustomRendrers
{
    class WifiConnectorAndroid : IWifiConnector
    {
        public void ConnectToWifi(string ssid, string password)
        {
            throw new NotImplementedException();
        }
    }
}