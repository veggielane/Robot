namespace Robot.Micro.Core.Messaging.Messages
{
    public class DebugMessage : BaseMessage
    {
        public string Msg { get; set; }
        public DebugMessage()
        {
            Msg = "";
        }
        public override string ToString()
        {
            return Msg;
        }
    }
}
