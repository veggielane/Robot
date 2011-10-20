using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Linq;

namespace Robot.Micro.Core.Reactive
{
    public class Observer : IObserver
    {
        private readonly ActionObject _onNext;
        private readonly ActionObject _onError;
        private readonly Action _onCompleted;
        public Observer(ActionObject onNext)
        {
            _onNext = onNext;
        }
        public Observer(ActionObject onNext, ActionObject onError, Action onCompleted)
        {
            _onNext = onNext;
            _onError = onError;
            _onCompleted = onCompleted;
        }
        public void OnNext(object value)
        {
            _onNext(value);
        }

        public void OnError(Exception error)
        {
            if (_onError != null) _onError(error);
        }

        public void OnCompleted()
        {
            if (_onCompleted != null) _onCompleted();
        }
    }
}
