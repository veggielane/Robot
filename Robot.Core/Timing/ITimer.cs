using System;

namespace Robot.Core.Timing
{
    public interface ITimer : IObservable<TickTime>
    {
        TickTime LastTickTime { get; }
        void Start();
        void Stop();
        void Delay(TimeSpan delay, Action func);
    }
}

