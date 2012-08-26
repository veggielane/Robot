using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robot.Core;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;
using Robot.Core.States;
using Robot.Core.Timing;

namespace Robot.Stompy
{
    public class StompyRobot:IRobot
    {
        public IMessageBus Bus { get; private set; }
        public IState CurrentState { get; private set; }
        public ITimer Timer { get; private set; }
        public bool IsRunning { get; private set; }

        public void Run()
        {
            Bus.Add(new DebugMessage { Msg = "Robot Starting" });
            Timer.Start();
        }

        public void Stop()
        {

        }

        public void Enable()
        {
 
        }

        public void Disable()
        {

        }

        public StompyRobot(IMessageBus bus, ITimer timer)
        {
            IsRunning = true;
            Bus = bus;
            Timer = timer;
        }

        public void Dispose()
        {

        }
    }
}
