using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Devices.CommunicationChannels;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Timing;

namespace Robot.Micro.Core
{
    public interface IRobot
    {
        MessageBus Bus { get; }
        CommunicationChannels Channels { get; }
        ITimer Timer { get; }
        bool IsRunning { get; }
        void Run();
    }
}
