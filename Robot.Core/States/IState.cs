using System;

#if MICRO
namespace Robot.Micro.Core.States
#else
namespace Robot.Core.States
#endif
{
    public interface IState:IDisposable
    {
        string Name { get; }
        void Start();
        void Stop();
    }
}
