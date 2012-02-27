using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Kinematics
{
    public class Body:IBody
    {
        private Matrix4 _position;
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
