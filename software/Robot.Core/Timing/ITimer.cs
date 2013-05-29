using System;

namespace Robot.Core.Timing
{
    public interface ITimer
    {
        IObservable<ITick> Ticks { get; }
        void Start();
        void Stop();
        TimeSpan Delta { get; }
        Tick LastTickTime { get; }
    }
}