using System;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Kinematics
{
    public class Leg4DOF:Leg3DOF
    {
        public Leg4DOF(IBody body) : base(body)
        {
        }
    }
}
