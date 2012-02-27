namespace Robot.Micro.Core.Messaging.Messages
{
    public class RemoteMessage : BaseMessage
    {
        public string Msg { get; set; }
        public RemoteMessage()
        {
            Msg = "";
        }
        public override string ToString()
        {
            return Msg;
        }
    }
}
