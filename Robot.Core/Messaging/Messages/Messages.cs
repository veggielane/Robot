using System;
#if MICRO
using Robot.Micro.Core.States;
namespace Robot.Micro.Core.Messaging.Messages
#else
using Robot.Core.States;
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

    /*
    public class MoveServo : BaseMessage
    {
        public override string ToString()
        {
            return "Move Servo";
        }
    }
    */

    public class StateRequest : BaseMessage
    {
        public IState State { get; private set; }
        public StateRequest(IState state)
        {
            State = state;
        }

        public override string ToString()
        {
            return "State Request: " + State.Name;
        }
    }
}
