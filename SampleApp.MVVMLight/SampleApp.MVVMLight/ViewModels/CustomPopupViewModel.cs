using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.ViewModels
{
    public class CustomPopupViewModel : BaseViewModel
    {
        public ICommand ConfirmCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public CustomPopupViewModel()
        {
            ConfirmCommand = new Command(OnConfirmClicked);
            CancelCommand = new Command(OnCancelClicked);
        }

        private void OnConfirmClicked(object obj)
        {
            throw new NotImplementedException();
        }
        private void OnCancelClicked(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
