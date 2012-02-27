using System;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Timing;

namespace Robot.Micro.Core
{
    public interface IRobot:IDisposable
    {
        IMessageBus Bus { get; }
        ITimer Timer { get; }
        bool IsRunning { get; }
        void Run();
        void Stop();
    }
}
