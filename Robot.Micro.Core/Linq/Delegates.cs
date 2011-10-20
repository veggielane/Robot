using System;

namespace Robot.Micro.Core.Linq
{
    public delegate bool Predicate(object o);
    public delegate void Action();
    public delegate void ActionObject(object o);
    public delegate void ActionString(String o);
}
