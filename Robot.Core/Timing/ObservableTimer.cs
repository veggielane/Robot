using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading;
using Robot.Core.Extensions;
using Robot.Core.Reactive;
namespace Robot.Core.Timing
{
    public class ObservableTimer : ConcurrentObservable<TickTime>, ITimer
    {
        #region TimerState enum

        public enum TimerState
        {
            Stopped = 0,
            Running,
            Stopping
        }

        #endregion

        private readonly bool _debug;

        public ObservableTimer()
            : this(new TimeSpan(0, 0, 0, 0, 100))
        {
        }

        public ObservableTimer(TimeSpan delta)
        {
            TickDelta = delta;
            State = TimerState.Stopped;
            LastTickTime = new TickTime();
            _debug = false;
        }

        public TimeSpan TickDelta { get; set; }
        public TimerState State { get; private set; }

        #region ITimer Members

        public TickTime LastTickTime { get; private set; }

        public virtual void Start()
        {
            if (State == TimerState.Running)
            {
                if (_debug) Debug.Write("Cannot start, Timer already running.");
                return;
            }

            if (State == TimerState.Stopping)
            {
                if (_debug) Debug.Write("Cannot start, Timer stopping.");
                return;
            }

            State = TimerState.Running;
            if (_debug) Debug.Write("Timer started.");

            while (State == TimerState.Running)
            {
                OnNext(LastTickTime);
                TimeSpan currentElapsed = LastTickTime.CurrentElapsed();
                if (currentElapsed < TickDelta)
                {
                    Thread.Sleep((TickDelta - currentElapsed).Milliseconds);
                }
                else if (_debug) Debug.Write("Tick over ran by :" + ((currentElapsed - TickDelta).Milliseconds));
                if (_debug) Debug.Write("Total tick time: " + (LastTickTime.CurrentElapsed().Milliseconds));
                LastTickTime.Update(TickDelta);
            }

            State = TimerState.Stopped;
            if (_debug) Debug.Write("Timer stopped.");
        }

        public virtual void Stop()
        {
            if (State == TimerState.Running)
            {
                State = TimerState.Stopping;
                if (_debug) Debug.Write("Timer stopping.");
            }
            else if (_debug) Debug.Write("Cannot stop, Timer already stopped.");
        }

        public void Delay(TimeSpan delay, Action func)
        {
            this.SubSample(delay.Milliseconds/TickDelta.Milliseconds).Skip(1).Subscribe((t) => func());
        }

        #endregion
    }
}
