using SampleApp.MVVMLight.Helpers;
using System;
using UIKit;

namespace SampleApp.MVVMLight.iOS.Helpers
{
    public class NotificationOperations : INotificationOperations
    {
        public void ClearNotification(long notificationId)
        {
            throw new NotImplementedException();
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