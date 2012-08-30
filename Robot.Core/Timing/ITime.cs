using System;
namespace Robot.Core.Timing
{
    public interface ITime
    {
        TimeSpan TimeElapsed { get; }
        TimeSpan TimeDelta { get; }
        long TickCount { get; }
    }
}
