namespace SampleApp.MVVMLight.Models
{
    public class iOSNotificationModel
    {
        public int ApnsCollapseId { get; set; }

        public Alert alert { get; set; }
        public long Badge { get; set; }
        public string sound { get; set; }
        public string ImageUrl { get; set; }
    }

    public partial class Alert
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }

}
