using System;
using System.Threading;
#if MICRO
using Microsoft.SPOT;
using Robot.Micro.Core.Reactive;
namespace Robot.Micro.Core.Timing
{
    public class ObservableTimer : Observable, ITimer
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

        #endregion
    }
}
#else
using Robot.Core.Reactive;
namespace Robot.Core.Timing
{
    public class ObservableTimer : Observable<TickTime>, ITimer
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

        #endregion
    }
}
#endif


