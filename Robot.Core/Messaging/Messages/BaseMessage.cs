using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Core.Messaging.Messages
{
    public abstract class BaseMessage : IMessage
    {
        public DateTime Time { get; private set; }
        protected BaseMessage()
        {
            Time = DateTime.Now;
        }
    }


}
