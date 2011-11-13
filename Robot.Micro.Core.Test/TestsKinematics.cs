using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Kinematics;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Test
{
    public class TestsKinematics
    {
        public void Test3DOF()
        {
            var body = new Body();
            var leg = new Leg3DOF(body)
            {
                BasePosition = Matrix4.Identity(),
                CoxaLength = 0.0,
                FemurLength = 10.0,
                TibiaLength = 5.0,
                FootPosition = new Vect3(10.0,0.0,-5.0).ToMatrix4(),
            };
            leg.Inverse();
        }
    }
}
