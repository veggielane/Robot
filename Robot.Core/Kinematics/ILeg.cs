#if MICRO
using Robot.Micro.Core.Maths;
namespace Robot.Micro.Core.Kinematics
#else
using Robot.Core.Maths;
namespace Robot.Core.Kinematics
#endif
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
