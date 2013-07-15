using Robot.Core.Maths;

namespace Robot.Core.Devices
{
    public class Servo
    {
        private Angle _angle = Angle.FromDegrees(0);
        public Angle Min = Angle.FromDegrees(-90.0);
        public Angle Max = Angle.FromDegrees(90.0);
        public Angle Offset = Angle.FromDegrees(0);

        public Angle Angle
        {
            get { return _angle; }
            set
            {
                if (value > Max)
                {
                    _angle = Max;
                }
                else if (value < Min)
                {
                    _angle = Min;
                }
                else
                {
                    _angle = value;
                }
               
            }
        }

        public int Pulse
        {
            get { return (int)Angle.Radians.Map(-MathsHelper.PiOverTwo, MathsHelper.PiOverTwo, 600.0, 2400.0); }
        }
    }
}
