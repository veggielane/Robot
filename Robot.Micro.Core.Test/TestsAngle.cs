using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Maths;
using GHIElectronics.NETMF.System;


namespace Robot.Micro.Core.Test
{
    public class TestsAngle
    {
        public void TestRadians()
        {
            Angle a1 = 0.0;
            MathsHelper.Cos(a1);

        }
        public void TestAdd3()
        {
            Assert.IsTrue(3 == 3,"Should Equal");
        }
    }
}
