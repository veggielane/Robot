using System;


namespace Robot.Core.Timing
{
    public interface ITimer
    {
        TickTime LastTickTime{get;}
        void Start();
        void Stop();
    }
}
