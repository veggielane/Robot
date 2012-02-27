using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Kinematics;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Test
{
    public class TestsKinematics
    {
        public void Test3DOF1()
        {
            var body = new Body{Position = Matrix4.Identity};
            var leg = new Leg3DOF(body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 2.0,
                FemurLength = 10.0,
                TibiaLength = 5.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                FootPosition = Matrix4.Translate(12.0, 0.0, -5.0),
            };

            Assert.NearlyEquals(leg.CoxaServo.Angle.Degrees,0.0);
            Assert.NearlyEquals(leg.FemurServo.Angle.Degrees, 0.0);
            Assert.NearlyEquals(leg.TibiaServo.Angle.Degrees, 0.0);


            body.Position *= Matrix4.Translate(0.0, 0.0, 1.0);
            body.Position *= Matrix4.Translate(0.0, 0.0, 1.0);
            body.Position *= Matrix4.Translate(0.0, 0.0, 1.0);
            body.Position *= Matrix4.Translate(0.0, 0.0, 1.0);

        }
        public void Test3DOF2()
        {
            var body = new Body { Position = Matrix4.Identity };
            var leg = new Leg3DOF(body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 2.0,
                FemurLength = 10.0,
                TibiaLength = 5.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                FootPosition = Matrix4.Translate(17.0, 0.0, 0.0),
            };

            Assert.NearlyEquals(leg.CoxaServo.Angle.Degrees, 0.0);
            Assert.NearlyEquals(leg.FemurServo.Angle.Degrees, 0.0);
            Assert.NearlyEquals(leg.TibiaServo.Angle.Degrees, -90.0);




        }
    }
}
