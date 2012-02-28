using System.Collections;
namespace Robot.Micro.Core.Linq
{
    public class Filter : IEnumerable
    {
        private class Enumerator : IEnumerator
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

        public Filter(IEnumerable e, Predicate p)
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
