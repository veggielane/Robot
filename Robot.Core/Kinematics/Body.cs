using Robot.Core.Maths;
namespace Robot.Core.Kinematics
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