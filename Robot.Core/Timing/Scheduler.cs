using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot.Core.Timing
{
    public class Scheduler
    {
        private readonly ITimer _timer;
        public Scheduler(ITimer timer)
        {
            _timer = timer;
        }
    }
}
