using System;
using Robot.Core.Messaging;

namespace Robot.Core
{
    public interface IRobot:IDisposable
    {
        IMessageBus Bus { get; }
        void Start();
        void Stop();
    }
}