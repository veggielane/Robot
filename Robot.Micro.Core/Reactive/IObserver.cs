using System;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Reactive
{
    public interface IObserver
    {
        void OnNext(object value);
        void OnError(Exception error);
        void OnCompleted();
    }
}
