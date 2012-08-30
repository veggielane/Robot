﻿using System;
using System.Collections.Generic;

namespace Robot.Core.Reactive
{
    public class Observable<T> : IObservable<T>, IDisposable
    {
        private readonly object _lock = new object();
        private readonly ICollection<IObserver<T>> _subscribers = new List<IObserver<T>>();
        private bool _isDisposed;

        #region IDisposable Members

        public virtual void Dispose()
        {
            _isDisposed = true;
            OnCompleted();
        }

        #endregion

        #region IObservable<T> Members

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("BufferedObservable<T>");
            lock (_lock)
                _subscribers.Add(observer);

            return new AnonymousDisposable(() => _subscribers.Remove(observer));
        }

        #endregion

        public void OnNext(T value)
        {
            lock (_lock)
                foreach (var sub in _subscribers)
                    sub.OnNext(value);
        }

        public void OnCompleted()
        {
            lock (_lock)
                foreach (var sub in _subscribers)
                    sub.OnCompleted();
        }

        public void OnError(Exception ex)
        {
            lock (_lock)
                foreach (var sub in _subscribers)
                    sub.OnError(ex);
        }
    }
}
