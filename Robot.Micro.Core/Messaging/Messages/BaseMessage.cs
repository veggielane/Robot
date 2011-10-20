using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Timing;

namespace Robot.Micro.Core.Messaging.Messages
{
    public abstract class BaseMessage : IMessage
    {
        public DateTime Time { get; set; }
        protected BaseMessage()
        {
            Time = DateTime.Now;
        }
    }
}
