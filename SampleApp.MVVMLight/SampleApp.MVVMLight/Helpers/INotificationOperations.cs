namespace SampleApp.MVVMLight.Helpers
{
    public interface INotificationOperations
    {
        void SetNotificationBadge(long badge);

        void ClearNotification(long notificationId);

        void ShowNotification(string title, string body);
    }
}
