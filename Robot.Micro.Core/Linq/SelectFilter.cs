using System;
using System.Collections;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Linq
{

    public class SelectFilter : IEnumerable
    {
        private class Enumerator : IEnumerator
        {
            readonly IEnumerator _e;
            readonly Predicate _p;

            internal Enumerator(IEnumerator e, Predicate p)
            {
                _e = e;
                _p = p;
            }

            object IEnumerator.Current
            {
                get { return _e.Current; }
            }

            void IEnumerator.Reset()
            {
                _e.Reset();
            }

            bool IEnumerator.MoveNext()
            {
                var b = _e.MoveNext();
                while (b && !_p(_e.Current))
                {
                    b = _e.MoveNext();
                }
                return b;
            }
        }
        IEnumerable e;
        Predicate p;

        public SelectFilter(IEnumerable e, Predicate p)
        {
            this.e = e;
            this.p = p;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(e.GetEnumerator(), p);
        }
    }
}
