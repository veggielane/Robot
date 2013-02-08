using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Core.Messaging.Messages
{
    public class DebugMessage:BaseMessage
    {
        public string Message { get; private set; }
        public DebugMessage(string message)
        {
            Message = message;
        }
        public override string ToString()
        {
            return "{0} {1}".Fmt(base.ToString(), Message);
        }
    }
}
