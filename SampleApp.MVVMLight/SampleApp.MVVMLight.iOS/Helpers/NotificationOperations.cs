using Foundation;
using Newtonsoft.Json;
using SampleApp.MVVMLight.Helpers;
using SampleApp.MVVMLight.Models;
using System;
using System.Collections.Generic;
using UIKit;
using UserNotifications;

namespace SampleApp.MVVMLight.iOS.Helpers
{
    public class NotificationOperations : INotificationOperations
    {
        public void ClearNotification(long notificationId)
        {
            try
            {
                List<string> ids = new List<string>();

                UNUserNotificationCenter.Current.GetDeliveredNotifications(completionHandler: (UNNotification[] t) =>
                {

                    foreach (UNNotification item in t)
                    {
                        UNNotificationRequest uNNotificationRequest = item.Request;

                        NSError nSError;

                        var data = NSJsonSerialization.Serialize((NSDictionary)uNNotificationRequest.Content.UserInfo["aps"], NSJsonWritingOptions.PrettyPrinted, out nSError);

                        var jsonstring = NSString.FromData(data, NSStringEncoding.UTF8).ToString();

                        var model = JsonConvert.DeserializeObject<iOSNotificationModel>(jsonstring);

                        if (notificationId == model.ApnsCollapseId)
                        {
                            ids.Add(uNNotificationRequest.Identifier);
                        }
                    }

                    //Clear the notification from notification center

                    UNUserNotificationCenter.Current.RemoveDeliveredNotifications(ids.ToArray());
                });

            }
            catch (Exception ex)
            {

            }
        }

        public void SetNotificationBadge(long badge)
        {
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = Convert.ToInt32(badge);
        }

        public void ShowNotification(string title, string body)
        {
            throw new NotImplementedException();
        }
    }
}