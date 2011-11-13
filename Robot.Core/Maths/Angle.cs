using System;
#if MICRO
using Microsoft.SPOT;
#endif

#if MICRO
namespace Robot.Micro.Core.Maths
#else
namespace Robot.Core.Maths
#endif
{
    public struct Angle
    {
        private const double RadToDeg = 180.0 / System.Math.PI;
        private const double DegToRad = System.Math.PI / 180.0;

        public double Radians { get; private set; }

        public double Degrees
        {
            get{ return Radians * RadToDeg; }
        }

        private Angle(double radians)
            : this()
        {
            Radians = radians;
        }

        public static Angle FromRadians(double radians)
        {
            return new Angle(radians);
        }

        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees * DegToRad);
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
        public static implicit operator Angle(double radians)
        {
            return new Angle(radians);
        }
        public static implicit operator double(Angle angle)
        {
            return angle.Radians;
        }
    }
}
