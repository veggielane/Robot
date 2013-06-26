using System;
using Robot.Core.FiniteStateMachine;
using Robot.Core.Messaging;
using Robot.Core.Timing;

namespace Robot.Core
{
    public interface IRobot:IDisposable
    {
        IMessageBus Bus { get; }
        ITimer Timer { get; }
        IStateMachine StateMachine { get; }
        void Start();
        void Stop();
    }
}