using System;

#if MICRO
namespace Robot.Micro.Core.Timing
#else
namespace Robot.Core.Timing
#endif
{
    public interface ITime
    {
        TimeSpan TimeElapsed { get; }
        TimeSpan TimeDelta { get; }
        long TickCount { get; }
    }
}
