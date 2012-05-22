using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Kinematics;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Stompy.Legs
{
    class LegLeftFront : Leg3DOF
    {
        public LegLeftFront(IBody body) : base(body)
        {
            Offset = Matrix4.Translate(0.0, 0.0, 0.0);
            CoxaLength = 40.0;
            FemurLength = 120.0;
            FemurInvert = false;
            TibiaLength = 85.0;
            TibiaOffset = Angle.FromDegrees(-90.0);
            //TibiaInvert = true,
            FootPosition = new Vect3(130.0, 0, -20);
        }
    }
}
