using System.Threading.Tasks;

namespace SampleApp.MVVMLight.Helpers
{
    public interface IOpenScannerPage
    {
        void OpenScanner();

        Task<string> ScanAsync();
    }
}
