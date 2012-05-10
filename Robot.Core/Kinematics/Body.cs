#if MICRO
using Microsoft.SPOT;
using Robot.Micro.Core.Maths;
namespace Robot.Micro.Core.Kinematics
#else
using Robot.Core.Maths;
namespace Robot.Core.Kinematics
#endif
{
    public class Body:IBody
    {
        private Matrix4 _position = Matrix4.Identity;

        public Matrix4 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (PositionChanged != null) PositionChanged();
            }
        }
        public event EventMatrix4 PositionChanged;
    }
}