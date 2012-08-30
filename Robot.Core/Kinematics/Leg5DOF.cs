using Robot.Core.Devices;

namespace Robot.Core.Kinematics
{
    public class Leg5DOF : Leg4DOF
    {
        public readonly Servo RotateServo = new Servo();
        public Leg5DOF(IBody body)
            : base(body)
        {

        }
    }
}