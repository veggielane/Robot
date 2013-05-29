using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Core.Maths;

namespace Robot.Core
{
    public static class Extensions
    {
        public static string Fmt(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static Vector3 ToVector3(this Matrix4 m)
        {
            return new Vector3(m.X, m.Y, m.Z);
        }

        public static Matrix4 ToMatrix4(this Vector3 v)
        {
            return Matrix4.Translate(v);
        }

        public static double Map(this double x, double inMin, double inMax, double outMin, double outMax)
        {
            return MathsHelper.Map(x, inMin, inMax, outMin, outMax);
        }

        public static double Clamp(this double x, double min, double max)
        {
            return MathsHelper.Clamp(x, min, max);
        }
        public static Angle Clamp(this Angle x, Angle min, Angle max)
        {
            return Angle.FromRadians(MathsHelper.Clamp(x.Radians, min.Radians, min.Radians));
        }

        public static double Pow(this double x, double power)
        {
            return MathsHelper.Pow(x, power);
        }

        public static double Sqrt(this double x)
        {
            return MathsHelper.Sqrt(x);
        }

        public static double Sin(this Angle a)
        {
            return MathsHelper.Sin(a);
        }

        public static double Cos(this Angle a)
        {
            return MathsHelper.Cos(a);
        }

        public static double Tan(this Angle a)
        {
            return MathsHelper.Tan(a);
        }


        public static IObservable<T> SubSample<T>(this IObservable<T> source, int interval)
        {
            return source.Where((o, i) => i % interval == 0);
        }
    }
}
