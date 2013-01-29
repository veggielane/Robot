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
    }
}
