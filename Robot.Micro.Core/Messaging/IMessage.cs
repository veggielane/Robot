using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Timing;

namespace Robot.Micro.Core.Messaging
{
    public interface IMessage
    {
        DateTime Time { get; }
        bool Remote { get; }
    }
}
