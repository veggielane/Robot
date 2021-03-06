using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Robot.Core.Timing
{
    public class Timer : ITimer
    {
        public IObservable<ITick> Ticks { get; private set; }

        public TimeSpan Delta { get; private set; }
        public Tick LastTickTime { get; private set; }

        private readonly ISubject<ITick> _subject;

        private readonly IObservable<Int64> _timer;

        public Timer()
        {
            _subject = new Subject<ITick>();

            Delta = TimeSpan.FromSeconds(0.25);
            _timer = Observable.Interval(Delta);
            Ticks = _subject.AsObservable();
            LastTickTime = new Tick();
        }

        private IDisposable _sub;
        public void Start()
        {

            _sub = _timer.Subscribe(t =>
                {
                    _subject.OnNext(LastTickTime);
                    LastTickTime.Update(Delta);
                });
        }

        public void Stop()
        {
            if (_sub != null) _sub.Dispose();
        }
    }
}