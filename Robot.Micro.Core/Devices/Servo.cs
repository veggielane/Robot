
using System;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Devices
{
    public class Servo
    {
        private Angle _angle = 0.0;

        public Angle Min = Angle.FromDegrees(-45.0);
        public Angle Max = Angle.FromDegrees(45.0);

        public Angle Angle
        {
            get { return _angle; }
            set { _angle = CheckLimits(value); }
        }

        public int Pulse
        {
            get { return (int)MathHelper.Map(Angle.Radians, -MathHelper.PiOverTwo, MathHelper.PiOverTwo, 600.0, 2400.0); }
        }

        private Angle CheckLimits(Angle angle)
        {
            if(angle > Max)
            {
                return Max;
            }
            if (angle < Min)
            {
                return Min;
            }
            return angle;
        }
    }
}
