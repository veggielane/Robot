using System;
using System.Threading.Tasks;
namespace Robot.Core.Timing
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
    }
}
