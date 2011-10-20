using System;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Timing
{
    public interface ITimer
    {
        TickTime LastTickTime{get;}
        void Start();
        void Stop();
    }
}
