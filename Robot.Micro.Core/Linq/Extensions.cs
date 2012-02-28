using System;
using System.Collections;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Linq
{
    public static class Extensions
    {
        //http://msdn.microsoft.com/en-us/library/bb341635.aspx
        public static IEnumerable Aggregate(this IEnumerable items, Predicate action)
        {
            throw new NotImplementedException();
        }

        public static bool All(this IEnumerable items, Predicate action)
        {
            foreach (var i in items)
                if (!action(i))
                    return false;
            return true;
        }

        public static bool Any(this IEnumerable items, Predicate action)
        {
            foreach (var i in items)
                if (action(i))
                    return true;
            return false;
        }

        //Average
        //Concat
        public static bool Contains(this IEnumerable items, object value)
        {
            foreach (var i in items)
                if (i.Equals(value))
                    return true;
            return false;
        }
        
        public static int Count(this IEnumerable items)
        {
            return Count(items, o => true);
        }

        public static int Count(this IEnumerable items, Predicate action)
        {
            var count = 0;
            items.ForEach(i =>{if (action(i))count++;});
            return count;
        }

        public static object DefaultIfEmpty(this IEnumerable items)
        {
            return items != null && Count(items) > 0 ? items : null;
        }

        public static IEnumerable Distinct(this IEnumerable first, IEnumerable second)
        {
            var set = new ArrayList();
            first.ForEach(item => set.Add(item));
            return new Filter(second, item => !set.Contains(item));
        }

        public static IEnumerable Empty()
        {
            throw new NotImplementedException();
        }
        
        
        public static IEnumerable Except(this IEnumerable first, IEnumerable second)
        {
            var set = new ArrayList();
            first.ForEach(item => set.Add(item));
            return new Filter(second, item => set.Contains(item));
        }

        public static object First(this IEnumerable items)
        {
            return First(items, o => true);
        }

        public static object First(this IEnumerable items, Predicate action)
        {
            foreach (var item in items)
                if (action(item))
                    return item;
            throw new InvalidOperationException();
        }

        public static object FirstOrDefault(this IEnumerable items)
        {
            return FirstOrDefault(items, o => true);
        }

        public static object FirstOrDefault(this IEnumerable items, Predicate action)
        {
            foreach (var item in items)
                if (action(item))
                    return item;
            return null;
        }


        //GroupBy
        //GroupJoin
        //Intersect
        //Join
        //Last
        //LastOrDefault
        //Max
        //Min

        public static IEnumerable OfType(this IEnumerable items, Type type)
        {
            return new Filter(items, item => item.GetType() == type);
        }
        

        //OrderBy
        //OrderByDescending
        //Range
        //Repeat
        //Reverse

        //Select
        
        public static IEnumerable Select(this IEnumerable items, Predicate action)
        {
            throw new NotImplementedException();
            return new SelectFilter(items, action);
        }


        
        //SelectMany
        //SequenceEqual
        //Single
        //SingleOrDefault
        //Skip While
        //Sum
        //Take

        //Union

        public static IEnumerable Where(this IEnumerable e, Predicate p)
        {
            return new Filter(e, p);
        }

        public static void ForEach(this IEnumerable items, ActionObject action)
        {
            foreach (var item in items)
                action(item);
        }
    }
}
