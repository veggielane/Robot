using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Linq;

namespace Robot.Micro.Core.Reactive
{
    public interface IObservable
    {
        IDisposable Subscribe(IObserver observer);
        IDisposable Subscribe(ActionObject onNext);
    }
}
