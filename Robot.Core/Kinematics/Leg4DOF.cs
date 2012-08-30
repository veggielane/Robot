using Robot.Core.Devices;

namespace Robot.Core.Kinematics
{
    public class Leg4DOF : Leg3DOF
    {
        public readonly Servo TarsServo = new Servo();
        public Leg4DOF(IBody body)
            : base(body)
        {

        }
    }
}