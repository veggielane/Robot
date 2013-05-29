using Robot.Core.Maths;

namespace Robot.Core.Kinematics
{
    public interface IBody
    {
        Matrix4 Position { get; set; }
    }
}
