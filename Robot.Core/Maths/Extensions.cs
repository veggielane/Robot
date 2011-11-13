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
    }
}
