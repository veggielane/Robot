using Robot.Core.Maths;
namespace Robot.Core.Kinematics
{
    public interface IBody
    {
        Matrix4 Position { get; set; }
        event EventMatrix4 PositionChanged;
    }
    public delegate void EventMatrix4();
}
