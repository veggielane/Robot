using System;
#if MICRO
namespace Robot.Micro.Core.Messaging.Messages
#else
namespace Robot.Core.Messaging.Messages
#endif
{
    public abstract class BaseMessage : IMessage
    {
        public DateTime Time { get; set; }
        public bool Remote { get; set; }
        protected BaseMessage()
        {
            Remote = false;
            Time = DateTime.Now;
        }
    }

    public class DebugMessage : BaseMessage
    {
        public string Msg { get; set; }
        public DebugMessage()
        {
            Msg = "";
        }
        public override string ToString()
        {
            return "Debug Message: " + Msg;
        }
    }


    public class RobotReadyMessage : BaseMessage
    {
        public override string ToString()
        {
            return "Robot Ready";
        }
    }

    public class MoveServo : BaseMessage
    {
        public override string ToString()
        {
            return "Robot Ready";
        }
    }
}
