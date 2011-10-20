using System;
using System.Collections;
using Robot.Micro.Core.Linq;

namespace Robot.Micro.Core.Reactive
{
    public class Observable : IObservable, IDisposable
    {
        private readonly object _lock = new object();
        private readonly ArrayList _subscribers = new ArrayList();
        private bool _isDisposed;

        #region IDisposable Members

        public virtual void Dispose()
        {
            _isDisposed = true;
            OnCompleted();
        }

        #endregion

        #region IObservable Members

        public IDisposable Subscribe(IObserver observer)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("BufferedObservable");
            lock (_lock)
                _subscribers.Add(observer);

            return new AnonymousDisposable(item => _subscribers.Remove(observer));
        }

        public IDisposable Subscribe(ActionObject observer)
        {
            return Subscribe(new Observer(observer));
        }

        #endregion

        public void OnNext(object value)
        {
            lock (_lock)
                foreach (var sub in _subscribers)
                    ((IObserver) sub).OnNext(value);
        }

        public void OnCompleted()
        {
            lock (_lock)
                foreach (var sub in _subscribers)
                    ((IObserver) sub).OnCompleted();
        }

        public void OnError(Exception ex)
        {
            lock (_lock)
                foreach (var sub in _subscribers)
                    ((IObserver) sub).OnError(ex);
        }
    }
}