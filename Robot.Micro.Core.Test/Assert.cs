using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Test
{
    public class Assert
    {
        public static void IsTrue(bool condition, string message)
        {
            if (!condition)
            {
                throw new AssertException(message);
            }
        }
        public static void IsFalse(bool condition, string message)
        {
            if (condition)
            {
                throw new AssertException(message);
            }
        }

        public static void NearlyEquals(double obja, double objb, double epsilon)
        {
            IsTrue(MathsHelper.NearlyEquals(obja,objb,epsilon), obja + " Does Not Nearly Equal " + objb + " +-" + epsilon.ToString("N10"));
        }
        public static void NearlyEquals(double obja, double objb)
        {
            NearlyEquals(obja,objb,0.00001);
        }

        public static void IsEqual(object obja, object objb)
        {
            if (obja is float || objb is float) throw new AssertException("cant compare floats");
            if (obja is double || objb is double) throw new AssertException("cant compare doubles");
            IsTrue(obja != objb, obja + " Does Not Equal" + objb);
        }
    }

    public class AssertException:Exception
    {
        public AssertException(string message)
            : base(message)
        {
            
        }
    }
}
