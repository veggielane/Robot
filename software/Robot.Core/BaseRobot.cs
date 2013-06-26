using Robot.Core.Devices;
using Robot.Core.FiniteStateMachine;
using Robot.Core.FiniteStateMachine.States;
using Robot.Core.Messaging;
using Robot.Core.Timing;

namespace Robot.Core
{
    public abstract class BaseRobot:IRobot
    {
        public IMessageBus Bus { get; private set; }
        public ITimer Timer { get; private set; }

        public IStateMachine StateMachine { get; private set; }

        protected BaseRobot(IMessageBus bus, ITimer timer)
        {
            Bus = bus;
            Timer = timer;
            Timer.Start();
            StateMachine = new StateMachine(bus);
            StateMachine.AddState(new IdleState());
            StateMachine.Start<IdleState>();
        }

        public abstract void Start();

        public abstract void Stop();

        public void Dispose()
        {
            
        }
    }
}
