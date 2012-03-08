using System;
#if MICRO
namespace Robot.Micro.Core.Messaging
#else
namespace Robot.Core.Messaging
#endif
{
    public interface IMessage
    {
        DateTime Time { get; }
        bool Remote { get; }
    }
}