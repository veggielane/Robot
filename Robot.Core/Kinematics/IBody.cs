#if MICRO
using Microsoft.SPOT;
using Robot.Micro.Core.Maths;
namespace Robot.Micro.Core.Kinematics
#else
using Robot.Core.Maths;
namespace Robot.Core.Kinematics
#endif
{
    public interface IBody
    {
        Matrix4 Position { get; set; }
        event EventMatrix4 PositionChanged;
    }
    public delegate void EventMatrix4();
}
