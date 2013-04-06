namespace Robot.Core.Maths
{
    public static class Extensions
    {
        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static bool NearlyEquals(this double x, double y, double epsilon = 0.00000001)
        {
            return MathsHelper.NearlyEquals(x, y, epsilon);
        }
    }
}