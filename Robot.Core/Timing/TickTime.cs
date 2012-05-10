using System;
#if MICRO
namespace Robot.Micro.Core.Timing
#else
namespace Robot.Core.Timing
#endif
{
    public class TickTime : ITime
    {
        private DateTime RealTime { get; set; }
        public TimeSpan RealTimeElapsed { get; private set; }
        public TimeSpan RealTimeDelta { get; private set; }
        public TimeSpan TimeElapsed { get; private set; }
        public TimeSpan TimeDelta { get; private set; }
        public long TickCount { get; private set; }
        public void Update(TimeSpan timeDelta)
        {
            TimeDelta = timeDelta;
            TimeElapsed += TimeDelta;
            var now = DateTime.Now;
            if (TickCount == 0)
                RealTime = now;
            RealTimeDelta = now - RealTime;
            RealTimeElapsed += RealTimeDelta;
            RealTime = now;
            TickCount++;
        }

        public TimeSpan CurrentElapsed()
        {
            if (TickCount == 0)
                return TimeSpan.Zero;
            return DateTime.Now - RealTime;
        }
        public override string ToString(){
            return RealTime.ToString();
        }
    }
}
