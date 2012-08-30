using System;
using Robot.Core.Messaging;
using Robot.Core.States;
using Robot.Core.Timing;
namespace Robot.Core
{
    public interface IRobot : IDisposable
    {
        
        ITimer Timer { get; }
        IMessageBus Bus { get; }
        IState CurrentState { get; }
        bool IsRunning { get; }
        void Run();
        void Stop();

        void Enable();
        void Disable();
    }
}
