namespace NotioficationPattern
{
    public class CustomException : Exception
    {
        public CustomException(string message, List<string> listMessage, int totalMessages)
            : base(message)
        {
            ListMessage = listMessage;
            TotalMessages = totalMessages;
        }

        public List<string> ListMessage { get; set; }
        public int TotalMessages { get; set; }
    }
}
