using Robot.Core.Devices;
using Robot.Core.Maths;
namespace Robot.Core.Kinematics
{
    public class Leg3DOF : ILeg
    {
        private readonly IBody _body;

        public Matrix4 Offset { get; set; }

        private Vect3 _footPosition;
        public Vect3 FootPosition
        {
            get { return _footPosition; }
            set 
            { 
                _footPosition = value;
                Inverse();
            }
        }

        private Vect3 _footOffset;
        public Vect3 FootOffset
        {
            get { return _footOffset; }
            set
            {
                _footOffset = value;
                Inverse();
            }
        }

        public Matrix4 BasePosition
        {
            get { return _body.Position * Offset; }
        }

        public readonly Servo CoxaServo = new Servo();
        public readonly Servo FemurServo = new Servo();
        public readonly Servo TibiaServo = new Servo();

        public Leg3DOF(IBody body)
        {
            _body = body;
            _body.PositionChanged += Inverse;
            _footOffset = Vect3.Zero;
        }

        public void Forward()
        {
            
        }

        public bool CoxaInvert;
        public bool FemurInvert;
        public bool TibiaInvert;

        public double CoxaLength { get; set; }
        public double FemurLength { get; set; }
        public double TibiaLength { get; set; }

        public Angle CoxaOffset { get; set; }
        public Angle FemurOffset { get; set; }
        public Angle TibiaOffset { get; set; }

        public void Inverse()
        {
             /*
             * Todo: 
             * - Elbow Up + Elbow Down
             * - Reduce Calcs
             * 
             * Jazar Pg. 331
             */
            var LtoF = (FootPosition + FootOffset) - BasePosition.ToVector3();

            var relative = (BasePosition.Rotation() * LtoF.ToMatrix4());
            var angle1 = MathsHelper.Atan2(relative.Y, relative.X);

            var a = (Matrix4.RotateZ(angle1) * Matrix4.Translate(CoxaLength, 0, 0)).ToVector3();
            var c = relative.ToVector3();

            var atoc = c - a;
            var angle3 = 2 * MathsHelper.Atan2(((FemurLength + TibiaLength).Pow(2) - (atoc.X.Pow(2) +atoc.Z.Pow(2))).Sqrt(),
                    (atoc.X.Pow(2) + atoc.Z.Pow(2) - (FemurLength - TibiaLength).Pow(2)).Sqrt());

            var angle2 = MathsHelper.Atan2(atoc.Z, atoc.X) + MathsHelper.Atan2(TibiaLength * (angle3).Sin(), FemurLength + TibiaLength * angle3.Cos());
            CoxaServo.Angle = (CoxaInvert ? -1 : 1) * (angle1 + CoxaOffset);
            FemurServo.Angle = (FemurInvert ? -1 : 1) * (angle2 + FemurOffset);
            TibiaServo.Angle = (TibiaInvert ? -1 : 1) * (angle3 + TibiaOffset);
        }

    }
}
