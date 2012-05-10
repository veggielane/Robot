using System;
#if MICRO
//using GHIElectronics.NETMF.System;
namespace Robot.Micro.Core.Maths
#else
namespace Robot.Core.Maths
#endif
{
    public enum Axis { X, Y, Z };

    public static class MathsHelper
    {
        public static double PI = Math.PI;
        public static double TwoPi = System.Math.PI * 2.0;
        public static double PiOverTwo = System.Math.PI / 2.0;

        #region Internaly used constants
        const double Sq2P1 = 2.414213562373095048802e0F;
        const double Sq2M1 = .414213562373095048802e0F;
        const double PIo2 = 1.570796326794896619231e0F;
        const double PIo4 = .785398163397448309615e0F;
        const double Log2E = 1.4426950408889634073599247F;
        const double Sqrt2 = 1.4142135623730950488016887F;
        const double Ln2 = 6.93147180559945286227e-01F;
        const double AtanP4 = .161536412982230228262e2F;
        const double AtanP3 = .26842548195503973794141e3F;
        const double AtanP2 = .11530293515404850115428136e4F;
        const double AtanP1 = .178040631643319697105464587e4F;
        const double AtanP0 = .89678597403663861959987488e3F;
        const double AtanQ4 = .5895697050844462222791e2F;
        const double AtanQ3 = .536265374031215315104235e3F;
        const double AtanQ2 = .16667838148816337184521798e4F;
        const double AtanQ1 = .207933497444540981287275926e4F;
        const double AtanQ0 = .89678597403663861962481162e3F;
        #endregion


        //public static readonly double PI = 3.14159265358979323846F;
        public static readonly double E = 2.71828182845904523536F;

        public static Double Sqrt(Double d)
        {
            return Math.Pow(d, 0.5);
        }
        public static Double Pow(Double x, Double y)
        {
            return Math.Pow(x, y);
        }
        public static Double Sin(Angle angle)
        {
#if MICRO
            return Cos((System.Math.PI / 2.0F) - angle);
#else
            return Math.Sin(angle.Radians);
#endif
        }
        public static Double Cos(Angle angle)
        {

#if MICRO
            // This function is based on the work described in
            // http://www.ganssle.com/approx/approx.pdf

            // Make X positive if negative
            if (angle < 0) { angle = 0.0F - angle; }

            // Get quadrand

            // Quadrand 0,  >-- Pi/2
            byte quadrand = 0;

            // Quadrand 1, Pi/2 -- Pi
            if ((angle > (System.Math.PI / 2F)) & (angle < (System.Math.PI)))
            {
                quadrand = 1;
                angle = System.Math.PI - angle;
            }

            // Quadrand 2, Pi -- 3Pi/2
            if ((angle > (System.Math.PI)) & (angle < ((3F * System.Math.PI) / 2)))
            {
                quadrand = 2;
                angle = System.Math.PI - angle;
            }

            // Quadrand 3 - 3Pi/2 -->
            if ((angle > ((3F * System.Math.PI) / 2)))
            {
                quadrand = 3;
                angle = (2F * System.Math.PI) - angle;
            }

            // Constants used for approximation
            const double c1 = 0.99999999999925182;
            const double c2 = -0.49999999997024012;
            const double c3 = 0.041666666473384543;
            const double c4 = -0.001388888418000423;
            const double c5 = 0.0000248010406484558;
            const double c6 = -0.0000002752469638432;
            const double c7 = 0.0000000019907856854;

            // X squared
            double x2 = angle * angle; ;

            // Check quadrand
            if ((quadrand == 0) | (quadrand == 3))
            {
                // Return positive for quadrand 0, 3
                return (c1 + x2 * (c2 + x2 * (c3 + x2 * (c4 + x2 * (c5 + x2 * (c6 + c7 * x2))))));
            }
            else
            {
                // Return negative for quadrand 1, 2
                return 0.0F - (c1 + x2 * (c2 + x2 * (c3 + x2 * (c4 + x2 * (c5 + x2 * (c6 + c7 * x2))))));
            }
#else
            return Math.Cos(angle.Radians);
#endif
        }
        public static Double Tan(Angle angle)
        {
#if MICRO
            return (Sin(angle) / Cos(angle));
#else
            return Math.Tan(angle.Radians);
#endif
        }

        public static Angle Acos(Double d)
        {
#if MICRO
            if ((d > 1.0F) || (d < -1.0F))
                throw new System.ArgumentOutOfRangeException();
            return (PIo2 - Asin(d));
#else
            return Math.Acos(d);
#endif
        }
        public static Angle Asin(Double d)
        {
#if MICRO
            double sign = 1.0F;

            if (d < 0.0F)
            {
                d = -d;
                sign = -1.0F;
            }

            if (d > 1.0F)
            {
                throw new ArgumentOutOfRangeException();
            }

            double temp = Sqrt(1.0F - (d * d));

            if (d > 0.7)
            {
                temp = PIo2 - Atan(temp / d);
            }
            else
            {
                temp = Atan(d / temp);
            }

            return (sign * temp);
#else
            return Math.Asin(d);
#endif
        }
        public static Angle Atan(Double d)
        {
#if MICRO
            if (d > 0.0F)
                return (Atans(d));
            return (-Atans(-d));
#else
            return Math.Asin(d);
#endif
        }

        public static Angle Atan2(Double y, Double x)
        {
#if MICRO
            if ((x + y) == x)
            {
                if ((x == 0F) & (y == 0F)) return 0F;

                if (x >= 0.0F)
                    return PIo2;
                else
                    return (-PIo2);
            }
            else if (y < 0.0F)
            {
                if (x >= 0.0F)
                    return ((PIo2 * 2) - Atans((-x) / y));
                else
                    return (((-PIo2) * 2) + Atans(x / y));

            }
            else if (x > 0.0F)
            {
                return (Atans(x / y));
            }
            else
            {
                return (-Atans((-x) / y));
            }
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
            return Math.Round(d);
        }

        private static double Atans(double d)
        {
            if (d < Sq2M1)
                return (Atanx(d));
            if (d > Sq2P1)
                return (PIo2 - Atanx(1.0F / d));
            return (PIo4 + Atanx((d - 1.0F) / (d + 1.0F)));
        }

        private static double Atanx(double d)
        {
            var argsq = d * d;
            var value = ((((AtanP4 * argsq + AtanP3) * argsq + AtanP2) * argsq + AtanP1) * argsq + AtanP0);
            value = value / (((((argsq + AtanQ4) * argsq + AtanQ3) * argsq + AtanQ2) * argsq + AtanQ1) * argsq + AtanQ0);
            return (value * d);
        }


    }
}
