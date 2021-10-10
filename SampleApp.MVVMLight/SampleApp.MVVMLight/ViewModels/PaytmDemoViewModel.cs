using AllInOneSDK;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.ViewModels
{
    public class PaytmDemoViewModel : BaseViewModel, PaymentCallback
    {
        public ICommand PayNowCommand { get; set; }

        public PaytmDemoViewModel()
        {
            PayNowCommand = new Command(OnPay);
        }

        public void error(string errorMessage)
        {
            AllInOnePlugin.DestroyInstance();
        }

        public void success(Dictionary<string, object> dictionary)
        {
            AllInOnePlugin.DestroyInstance();
        }

        public void OnPay(object obj)
        {
            //AllInOnePlugin.startTransaction(orderId, mid, txnToken, amount, callbackurl, isStaging, restrictAppInvoke, this); // this -> PaymentCallback

            AllInOnePlugin.startTransaction("", "12345", "", "", "", false, false, this); // this -> PaymentCallback
        }
    }
}
