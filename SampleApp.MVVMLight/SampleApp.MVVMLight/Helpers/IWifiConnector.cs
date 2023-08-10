using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.MVVMLight.Helpers
{
    public interface IWifiConnector
    {
        void ConnectToWifi(string ssid, string password);
        Task<IEnumerable<string>> GetAvailableNetworksAsync();
        Task<IEnumerable<string>> GetAvailableNetworksAsync2();

    }
}
