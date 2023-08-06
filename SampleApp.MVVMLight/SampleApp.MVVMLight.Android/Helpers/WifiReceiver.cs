using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SampleApp.MVVMLight.Droid.Helpers
{
    public class WifiReceiver : BroadcastReceiver
    {
        private WifiManager wifi;
        private List<string> wifiNetworks;
        private AutoResetEvent receiverARE;
        private Timer tmr;
        private const int TIMEOUT_MILLIS = 20000; // 20 seconds timeout

        public WifiReceiver()
        {

        }
        public WifiReceiver(WifiManager wifi)
        {
            this.wifi = wifi;
            wifiNetworks = new List<string>();
            receiverARE = new AutoResetEvent(false);
        }

        public IEnumerable<string> Scan()
        {
            tmr = new Timer(Timeout, null, TIMEOUT_MILLIS, System.Threading.Timeout.Infinite);
            wifi.StartScan();
            receiverARE.WaitOne();
            return wifiNetworks;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            IList<ScanResult> scanwifinetworks = wifi.ScanResults;
            foreach (ScanResult wifinetwork in scanwifinetworks)
            {
                wifiNetworks.Add(wifinetwork.Ssid);
            }

            receiverARE.Set();
        }

        private void Timeout(object sender)
        {
            // NOTE release scan, which we are using now, or we throw an error?
            receiverARE.Set();
        }
    }
}