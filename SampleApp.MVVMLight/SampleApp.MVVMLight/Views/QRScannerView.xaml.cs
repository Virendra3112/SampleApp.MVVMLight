using CommonServiceLocator;
using SampleApp.MVVMLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScannerView : ContentPage
    {
        private QRScannerViewModel QRScannerVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QRScannerViewModel>();
            }
        }
        public QRScannerView()
        {
            InitializeComponent();
            BindingContext = QRScannerVM;
        }
    }
}