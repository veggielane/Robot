using System;
#if MICRO
using Robot.Micro.Core.Timing;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.States;
namespace Robot.Micro.Core
#else
using Robot.Core.Messaging;
using Robot.Core.States;
using Robot.Core.Timing;
namespace Robot.Core
#endif
{
    public interface IRobot : IDisposable
    {
        
        ITimer Timer { get; }
        IMessageBus Bus { get; }
        IState CurrentState { get; }
        bool IsRunning { get; }
        void Run();
        void Stop();

    }
}
