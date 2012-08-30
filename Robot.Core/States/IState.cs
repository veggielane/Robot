using System;
namespace Robot.Core.States
{
    public interface IState:IDisposable
    {
        string Name { get; }
        void Start();
        void Stop();
    }
}
