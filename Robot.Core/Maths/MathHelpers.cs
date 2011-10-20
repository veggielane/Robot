using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot.Core.Maths
{
    public class MathHelpers
    {
        public static double Map(double x, double inMin, double inMax, double outMin, double outMax)
        {
            return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
}
