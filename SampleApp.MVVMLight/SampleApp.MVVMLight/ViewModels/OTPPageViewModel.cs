using SampleApp.MVVMLight.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.ViewModels
{
    public class OTPPageViewModel : BaseViewModel
    {
        private string _smSEntry;
        public string SmSEntry
        {
            get { return _smSEntry; }
            set { _smSEntry = value; OnPropertyChanged(); }
        }
        public ICommand WaitCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }


        public OTPPageViewModel()
        {
            WaitCommand = new Command(OnWait);
            //OpenPopupCommand = new Command(OnOpenPopup);

            this.Subscribe<string>(Events.SmsRecieved, code =>
            {
                SmSEntry = code;
            });
        }

        private void OnWait(object obj)
        {
            CommonServices.ListenToSmsRetriever();
        }
    }
}
