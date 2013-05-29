using Robot.Core.Devices;
using Robot.Core.FiniteStateMachine;
using Robot.Core.Messaging;
using Robot.Core.Timing;

namespace Robot.Core
{
    public class BaseRobot:IRobot
    {
        public IMessageBus Bus { get; private set; }
        public ITimer Timer { get; private set; }

        private IStateMachine StateMachine { get; set; }

        protected BaseRobot(IMessageBus bus, ITimer timer)
        {
            Bus = bus;
            Timer = timer;

            StateMachine = new StateMachine();
        }

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
