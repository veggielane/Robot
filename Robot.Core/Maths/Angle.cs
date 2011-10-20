using System;
namespace Robot.Core.Maths
{
    public struct Angle
    {
        public const double TwoPi = Math.PI * 2.0;
        private const double RadToDeg = 360.0 / (2.0 * Math.PI);
        private const double DegToRad = (2.0 * Math.PI) / 360.0;

        public double Radians { get; private set; }

        public double Degrees
        {
            get
            {
                return Radians * RadToDeg;
            }
        }

        public static Angle FromRadians(double radians)
        {
            return new Angle(radians);
        }

        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees * DegToRad);
        }

        private Angle(double radians) : this()
        {
            Radians = radians;
        }

        public override string ToString()
        {
            return Degrees + " Degrees";
        }

        public static Angle Zero
        {
            get { return new Angle(); }
        }

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle(a1.Radians + a2.Radians);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle(a1.Radians - a2.Radians);
        }

        public static Angle operator *(Angle a, double d)
        {
            return new Angle(a.Radians * d);
        }

        public static Angle operator /(Angle a, double d)
        {
            return new Angle(a.Radians / d);
        }
    }
}
