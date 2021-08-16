using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.Phone;
using Android.Gms.Common.Apis;
using SampleApp.MVVMLight.Helpers;
using System.Linq;
using System.Text.RegularExpressions;

namespace SampleApp.MVVMLight.Droid.Helpers
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { SmsRetriever.SmsRetrievedAction })]
    public class SmsReceiver : BroadcastReceiver
    {
        private static readonly string[] OtpMessageBodyKeywordSet = { "TestApp OTP" }; //You must define your own Keywords
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {

                if (intent.Action != SmsRetriever.SmsRetrievedAction) return;
                var bundle = intent.Extras;
                if (bundle == null) return;
                var status = (Statuses)bundle.Get(SmsRetriever.ExtraStatus);
                switch (status.StatusCode)
                {
                    case CommonStatusCodes.Success:
                        // Get SMS message contents
                        var message = (string)bundle.Get(SmsRetriever.ExtraSmsMessage);
                        // Extract one-time code from the message and complete verification
                        // by sending the code back to your server.
                        var foundKeyword = OtpMessageBodyKeywordSet.Any(k => message.Contains(k));
                        if (!foundKeyword) return;
                        var code = ExtractNumber(message);
                        Utilities.Notify(Events.SmsRecieved, code);
                        break;
                    case CommonStatusCodes.Timeout:
                        // Waiting for SMS timed out (5 minutes)
                        // Handle the error ...
                        break;
                }

            }
            catch (System.Exception)
            {
                // ignored
            }
        }
        private static string ExtractNumber(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            var number = Regex.Match(text, @"\d+").Value;
            return number;
        }
    }

}