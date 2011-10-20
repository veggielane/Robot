using System;
using Robot.Micro.Core.Linq;

namespace Robot.Micro.Core.Reactive
{
    public class AnonymousDisposable : IDisposable
    {
        readonly ActionObject _dispose;
        public AnonymousDisposable(ActionObject dispose)
        {
            _dispose = dispose;
        }

        public void Dispose()
        {
            _dispose(null);
        }
    }
}
