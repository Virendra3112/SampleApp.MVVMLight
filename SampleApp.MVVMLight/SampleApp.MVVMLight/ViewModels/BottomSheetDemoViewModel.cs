using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.ViewModels
{
    public class BottomSheetDemoViewModel : BaseViewModel
    {
        public ICommand OpenPopupCommand { get; set; }

        public BottomSheetDemoViewModel()
        {
            OpenPopupCommand = new Command(OnOpenPopup);

        }

        private async void OnOpenPopup(object obj)        
        {
            //await Sheet.OpenSheet();

        }
    }
}
