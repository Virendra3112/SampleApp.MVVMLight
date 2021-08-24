using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.MVVMLight.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationIconWithBadge : ContentView
    {
        private static List<NotificationIconWithBadge> _instanceList = new List<NotificationIconWithBadge>();
        public static int NotificationBellIconCount = 0;
        public static readonly BindableProperty NotificationCountProperty = BindableProperty.Create(nameof(BadgeCount), returnType: typeof(int), declaringType: typeof(int), defaultValue: 0);

        public int BadgeCount
        {
            get
            {
                return (int)GetValue(NotificationCountProperty);
            }
            private set
            {
                SetValue(NotificationCountProperty, value);
                frmNotificationBubble.IsVisible = value > 0;
            }
        }

        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create(nameof(TappedCommand), returnType: typeof(Command), declaringType: typeof(Command), defaultValue: null);

        public Command TappedCommand
        {
            get
            {
                return (Command)GetValue(TappedCommandProperty);
            }
            set
            {
                SetValue(TappedCommandProperty, value);
            }
        }

        public NotificationIconWithBadge()
        {
            InitializeComponent();
            _instanceList.Add(this);
            BadgeCount = NotificationBellIconCount;
        }

        public static void SetNotificationCount(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Badge count can't be zero.");

            foreach (var instance in _instanceList)
                instance.BadgeCount = count;
            NotificationBellIconCount = count;
        }

        public static int GetNotificationCount()
        {
            return NotificationBellIconCount;
        }
    }
}