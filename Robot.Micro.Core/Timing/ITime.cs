using System;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Timing
{
    public interface ITime
    {
        TimeSpan TimeElapsed { get; }
        TimeSpan TimeDelta { get; }
        long TickCount { get; }
    }
}
