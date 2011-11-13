using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Kinematics
{
    public interface IBody
    {
        Matrix4 Position { get; set; }
    }
}
