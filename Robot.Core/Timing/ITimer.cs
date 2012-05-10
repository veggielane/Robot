using System;
#if MICRO
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Timing
{
    public interface ITimer:IObservable
    {
        TickTime LastTickTime{get;}
        void Start();
        void Stop();
    }
}
#else
namespace Robot.Core.Timing
{
    public interface ITimer:IObservable<TickTime>
    {
        TickTime LastTickTime{get;}
        void Start();
        void Stop();
    }
}
#endif

