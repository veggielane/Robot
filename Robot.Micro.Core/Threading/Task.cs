using System.Threading;
using Robot.Micro.Core.Linq;

namespace Robot.Micro.Core.Threading
{
    public class Task
    {
        private readonly Action _task;
        private readonly Thread _thread;
        public Task(Action task)
        {
            _task = task;
            _thread = new Thread(Activity); 
        }
        private void Activity()
        {
            _task();
        }
        public void Start()
        {
            _thread.Start();
        }
        public void Stop()
        {
            _thread.Abort();
        }
    }
}
