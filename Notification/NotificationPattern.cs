namespace NotioficationPattern.Notification
{
    public class NotificationPattern : INotificationPattern
    {
        public List<string> ListMessage { get; set; }
        public string Message { get; set; }
        public int TotalMessages { get; set; }

        public void AddError(string message)
        {
            if (ListMessage == null)
                ListMessage = new List<string>();

            ListMessage.Add(message);
        }
    }
}
