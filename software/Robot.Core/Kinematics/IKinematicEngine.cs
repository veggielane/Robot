using System.Collections.Generic;

namespace Robot.Core.Kinematics
{
    public interface IKinematicEngine
    {
        IBody Body { get; }
        IList<ILeg> Legs { get; }
        void Inverse();
    }

    public class KinematicEngine : IKinematicEngine
    {
        public IBody Body { get; private set; }
        public IList<ILeg> Legs { get; private set; }

        public KinematicEngine(IBody body)
        {
            Body = body;
            Legs = new List<ILeg>();
        }

        public KinematicEngine(IBody body, IList<ILeg> legs)
            : this(body)
        {
            Legs = legs;
        }


        public void Inverse()
        {
            foreach (var leg in Legs)
            {
                leg.Inverse(Body);
            }
        }
    }
}