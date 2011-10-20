
using System;
using System.Collections;
using Microsoft.SPOT;
using Robot.Micro.Core.Linq;

namespace Robot.Micro.Core.Reactive
{
    public class FilterObservable : Observable
    {
        public FilterObservable(IObservable observable, Predicate p)
        {
            observable.Subscribe(new Observer(item =>
                                                  {
                                                      if (p(item))
                                                      {
                                                          OnNext(item);
                                                      }
                                                  }));
        }
    }
}