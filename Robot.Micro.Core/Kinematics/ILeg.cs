using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Kinematics
{
    public interface ILeg
    {

        Matrix4 BasePosition { get; }
        Matrix4 FootPosition { get; set; }
        void Forward();
        void Inverse();
    }
}
