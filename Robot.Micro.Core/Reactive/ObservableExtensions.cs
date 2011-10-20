using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Linq;

namespace Robot.Micro.Core.Reactive
{
    public static class ObservableExtensions
    {

        public static IObservable Where(this IObservable source, Predicate p)
        {
            if (source == null)
                throw Error.ArgumentNullException("source");
            if (p == null)
                throw Error.ArgumentNullException("predicate");
            return new FilterObservable(source,p);
        }

        public static IObservable SubSample(this IObservable source, int interval)
        {
            var i = -1;
            return source.Where(o =>
            {
                i = (i + 1) % interval;
                return i == 0;
            });
        }
        public static IObservable OfType(this IObservable source, Type type)
        {
            return source.Where(o => type != null && o.GetType() == type);
        }
    }
}
