using System.Collections;
namespace Robot.Micro.Core.Linq
{
    class Filter : IEnumerable
    {
        internal class Enumerator : IEnumerator
        {
            IEnumerator e;
            Predicate p;

            internal Enumerator(IEnumerator e, Predicate p)
            {
                this.e = e;
                this.p = p;
            }

            object IEnumerator.Current
            {
                get { return e.Current; }
            }

            void IEnumerator.Reset()
            {
                e.Reset();
            }

            bool IEnumerator.MoveNext()
            {
                var b = e.MoveNext();
                while (b && !p(e.Current))
                {
                    b = e.MoveNext();
                }
                return b;
            }
        }
        IEnumerable e;
        Predicate p;

        internal Filter(IEnumerable e, Predicate p)
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
