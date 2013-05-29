using Robot.Core.Maths;

namespace Robot.Core.Kinematics
{
    public class Body:IBody
    {
        public Matrix4 Position { get; set; }
    }
}