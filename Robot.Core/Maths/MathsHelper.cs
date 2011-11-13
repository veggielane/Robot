using System;
#if MICRO
using GHIElectronics.NETMF.System;
using Microsoft.SPOT;
namespace Robot.Micro.Core.Maths
#else
namespace Robot.Core.Maths
#endif
{
    public enum Axis { X, Y, Z };

    public static class MathsHelper
    {
        public static double Pi = System.Math.PI;
        public static double TwoPi = System.Math.PI * 2.0;
        public static double PiOverTwo = System.Math.PI / 2.0;

        public static Double Sqrt(Double d)
        {
#if MICRO
            return MathEx.Sqrt(d);
#else
            return Math.Pow(d, 0.5);
#endif
        }
        public static Double Pow(Double x, Double y)
        {
#if MICRO
            return MathEx.Pow(x, y);
#else
            return Math.Pow(x, y);
#endif
        }
        public static Double Sin(Angle angle)
        {
#if MICRO
            return MathEx.Sin(angle.Radians);
#else
            return Math.Sin(angle.Radians);
#endif
        }
        public static Double Cos(Angle angle)
        {
#if MICRO
            return MathEx.Cos(angle);
#else

            return Math.Cos(angle.Radians);
#endif
        }
        public static Double Tan(Angle angle)
        {
#if MICRO
            return MathEx.Tan(angle.Radians);
#else
            return Math.Tan(angle.Radians);
#endif
        }

        public static Angle Acos(Double d)
        {
#if MICRO
            return MathEx.Acos(d);
#else
            return Math.Acos(d);
#endif
        }
        public static Angle Asin(Double d)
        {
#if MICRO
            return MathEx.Asin(d);
#else
            return Math.Asin(d);
#endif
        }
        public static Angle Atan(Double d)
        {
#if MICRO
            return MathEx.Atan(d);
#else
            return Math.Asin(d);
#endif
        }
        public static Angle Atan2(Double y, Double x)
        {
#if MICRO
            return MathEx.Atan2(y, x);
#else
            return Math.Atan2(y, x);
#endif
        }

        public static Double Abs(Double d)
        {
            if (d >= 0.0)
                return d;
            return -d;
        }


        public static bool NearlyEquals(Double x, Double y, Double epsilon)
        {
            return Abs(x - y) < epsilon;
        }
        public static bool NearlyEquals(Double x, Double y)
        {
            return NearlyEquals(x, y, 0.00001);
        }

        public static Double Round(Double d)
        {
            return System.Math.Round(d);
        }
    }
}
