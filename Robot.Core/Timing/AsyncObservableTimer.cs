using System;
using System.Threading.Tasks;
using Robot.Core.Timing;

namespace Robot.Micro.Core.Timing
{
    public class AsyncObservableTimer : ObservableTimer
    {
        private Task RunningTask { get; set; }

        public AsyncObservableTimer()
        {

        }
        public AsyncObservableTimer(TimeSpan delta)
            : base(delta)
        {
            
        }

        public override void Start()
        {
            RunningTask = new Task(() => base.Start());
            RunningTask.Start();
        }

        public override void Stop()
        {
            base.Stop();
            //RunningTask.Stop();
        }
    }
}
