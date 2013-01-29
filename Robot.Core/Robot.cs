using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Robot.Core.Messaging;

namespace Robot.Core
{
    public interface IRobot
    {
        MessageBus Bus { get; }  
    }

    public class BaseRobot:IRobot
    {
        public MessageBus Bus { get; private set; }

        public BaseRobot()
        {
            Bus = new MessageBus();
        }
    }
}
