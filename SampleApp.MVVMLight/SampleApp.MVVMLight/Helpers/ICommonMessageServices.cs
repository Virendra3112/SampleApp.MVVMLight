using System;
using Xamarin.Forms;

namespace SampleApp.MVVMLight.Helpers
{
    public interface ICommonMessageServices
    {
        void StartSMSService();
    }

    public static class CommonServices
    {
        public static void ListenToSmsRetriever()
        {

            DependencyService.Get<IListenToSmsRetriever>()?.ListenToSmsRetriever();
        }
    }


    public interface IListenToSmsRetriever
    {
        void ListenToSmsRetriever();
    }

    public static class Utilities
    {

        private static readonly object cc = new object();
        public static void Subscribe<TArgs>(this object subscriber, Events eventSubscribed, Action<TArgs> callBack)
        {

            MessagingCenter.Subscribe(subscriber, eventSubscribed.ToString(), new Action<object, TArgs>((e, a) =>
            {
                callBack(a);
            }));
        }

        public static void Notify<TArgs>(Events eventNotified, TArgs argument)
        {
            MessagingCenter.Send(cc, eventNotified.ToString(), argument);
        }

    }

    public enum Events
    {
        SmsRecieved,
    }

}
