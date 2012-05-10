#if MICRO
namespace Robot.Micro.Core.Maths
#else
namespace Robot.Core.Maths
#endif
{
    public static class Extensions
    {
        public static Vect3 ToVector3(this Matrix4 m)
        {
            return new Vect3(m[1, 4], m[2, 4], m[3, 4]);
        }

        public static Matrix4 ToMatrix4(this Vect3 v)
        {
            return Matrix4.Translate(v.X, v.Y, v.Z);
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


    }
}
