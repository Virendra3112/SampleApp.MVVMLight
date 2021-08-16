using Android.App;
using Android.Gms.Auth.Api.Phone;
using SampleApp.MVVMLight.Droid.Helpers;
using SampleApp.MVVMLight.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(ListenToSms))]
namespace SampleApp.MVVMLight.Droid.Helpers
{
    public class ListenToSms : IListenToSmsRetriever
    {

        public void ListenToSmsRetriever()
        {
            SmsRetrieverClient client = SmsRetriever.GetClient(Android.App.Application.Context);
            var task = client.StartSmsRetriever();
            //task.AddOnSuccessListener(new SuccessListener());
            //task.AddOnFailureListener(new FailureListener());
        }

        //private class SuccessListener : IOnSuccessListener
        //{
        //    public IntPtr Handle => throw new NotImplementedException();

        //    public int JniIdentityHashCode => throw new NotImplementedException();

        //    public JniObjectReference PeerReference => throw new NotImplementedException();

        //    public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        //    public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        //    public void Dispose()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void Disposed()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void DisposeUnlessReferenced()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void Finalized()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void OnSuccess(Java.Lang.Object result)
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void SetJniIdentityHashCode(int value)
        //    {
        //       // throw new NotImplementedException();
        //    }

        //    public void SetJniManagedPeerState(JniManagedPeerStates value)
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void SetPeerReference(JniObjectReference reference)
        //    {
        //       // throw new NotImplementedException();
        //    }

        //    public void UnregisterFromRuntime()
        //    {
        //       // throw new NotImplementedException();
        //    }
        //}

        //private class FailureListener : IOnFailureListener
        //{
        //    public IntPtr Handle => throw new NotImplementedException();

        //    public int JniIdentityHashCode => throw new NotImplementedException();

        //    public JniObjectReference PeerReference => throw new NotImplementedException();

        //    public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        //    public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        //    public void Dispose()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void Disposed()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void DisposeUnlessReferenced()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void Finalized()
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void OnFailure(Java.Lang.Exception e)
        //    {
        //       //throw new NotImplementedException();
        //    }

        //    public void SetJniIdentityHashCode(int value)
        //    {
        //       // throw new NotImplementedException();
        //    }

        //    public void SetJniManagedPeerState(JniManagedPeerStates value)
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void SetPeerReference(JniObjectReference reference)
        //    {
        //       // throw new NotImplementedException();
        //    }

        //    public void UnregisterFromRuntime()
        //    {
        //        //throw new NotImplementedException();
        //    }
        //}
    }
}