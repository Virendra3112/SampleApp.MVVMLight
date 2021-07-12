using System;

namespace SampleApp.MVVMLight.Models.UIModels
{
    public class Notification
    {
        public long NotificationId { get; set; }
        public string Title { get; set; }
        public long Body { get; set; }
        public DateTime ReceivedDateTime { get; set; }
        public string ImageURL { get; set; }
        public bool IsRead { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSelected { get; set; }
        public string ExtraParameterFirst { get; set; }
        public string ExtraParameterSeccond { get; set; }
    }
}
