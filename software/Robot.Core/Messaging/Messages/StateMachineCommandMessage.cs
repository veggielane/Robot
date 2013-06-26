using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot.Core.Messaging.Messages
{
    public class StateMachineCommandMessage : BaseMessage
    {
        public Type Command { get; private set; }
        public StateMachineCommandMessage(Type command)
        {
            Command = command;
        }
        public override string ToString()
        {
            return "{0} {1}".Fmt(base.ToString(), Command);
        }
    }
}
