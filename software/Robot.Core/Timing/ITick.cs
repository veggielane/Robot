using System;

namespace Robot.Core.Timing
{
    public interface ITick
    {

        TimeSpan TimeElapsed { get; }
        TimeSpan TimeDelta { get; }
        long TickCount { get; }

        void Update(TimeSpan delta);
    }
}