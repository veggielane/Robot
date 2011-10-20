using System;

namespace Robot.Micro.Core.Maths
{
    public class MathHelper
    {
        public static double TwoPi = Math.PI * 2.0;
        public static double PiOverTwo = Math.PI / 2.0;

        public static double Map(double x, double inMin, double inMax, double outMin, double outMax)
        {
            return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
}
