using System;
#if MICRO
using Robot.Micro.Core.Linq;
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Timing
{
    public interface ITimer:IObservable
    {
        TickTime LastTickTime{get;}
        void Start();
        void Stop();
        void Delay(TimeSpan delay, Action func);
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
        void Delay(TimeSpan delay, Action func);
    }
}
#endif

