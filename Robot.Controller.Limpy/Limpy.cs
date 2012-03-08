using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robot.Core;
using Robot.Core.Messaging;
using Robot.Core.Timing;

namespace Robot.Controller.Limpy
{
    public class Limpy:IRobot
    {
        public IMessageBus Bus { get; private set; }


        public ITimer Timer { get; private set; }
        public bool IsRunning { get; private set; }


        public Limpy(IMessageBus bus, ITimer timer)
        {
            Bus = bus;
            Timer = timer;

        }

        public void Dispose()
        {
            
        }


        public void Run()
        {
            
        }

        public void Stop()
        {
            
        }
    }
}
