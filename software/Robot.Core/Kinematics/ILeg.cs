using Robot.Core.Maths;

namespace Robot.Core.Kinematics
{
    public interface ILeg
    {
        Matrix4 BasePosition { get; }
        Vector3 FootPosition { get; set; }
        Vector3 FootOffset { get; set; }
        void Inverse(IBody body);
    }
}