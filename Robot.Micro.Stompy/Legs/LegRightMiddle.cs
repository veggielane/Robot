using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Kinematics;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Stompy.Legs
{
    class LegRightMiddle : Leg3DOF
    {
        public LegRightMiddle(IBody body)
            : base(body)
        {
            Offset = Matrix4.Translate(0.0, 0.0, 0.0);
            CoxaLength = 35.0;
            FemurLength = 52.0;
            //FemurInvert = true,
            TibiaLength = 48.0;
            TibiaOffset = Angle.FromDegrees(-90.0);
            //TibiaInvert = true,
            FootPosition = new Vect3(35.0 + 52.0, 0.0, -48.0);
        }
    }
}
