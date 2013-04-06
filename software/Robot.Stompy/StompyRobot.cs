using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Core;
using Robot.Core.Devices;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;

namespace Robot.Stompy
{
    public class StompyRobot:BaseRobot
    {
        public StompyRobot(IMessageBus bus)
            : base(bus)
        {

        }

        public override void Start()
        {
            Bus.Add(new DebugMessage("Robot Starting!!"));
        }

        public override void Stop()
        {

        }
        public override void Dispose()
        {
            Stop();
        }
    }
}
