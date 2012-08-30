using Robot.Core.Maths;
namespace Robot.Core.Kinematics
{
    public interface ILeg
    {
        Matrix4 BasePosition { get; }
        Vect3 FootPosition { get; set; }
        Vect3 FootOffset { get; set; }
        void Forward();
        void Inverse();
    }
}
