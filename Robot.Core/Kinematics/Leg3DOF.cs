#if MICRO
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Maths;
namespace Robot.Micro.Core.Kinematics
#else
using System;
using Robot.Core.Devices;
using Robot.Core.Maths;
namespace Robot.Core.Kinematics
#endif
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

        public readonly Servo CoxaServo = new Servo
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };

        public readonly Servo FemurServo = new Servo
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };

        public readonly Servo TibiaServo = new Servo
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };


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
            Vect3 LtoF = (FootPosition + FootOffset) - BasePosition.ToVector3();

            var relative = (BasePosition.Rotation() * LtoF.ToMatrix4());
            //Debug.WriteLine(relative.ToString());
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

            //Debug.WriteLine(CoxaServo.Angle);
            //Debug.WriteLine(FemurServo.Angle);
            //Debug.WriteLine(TibiaServo.Angle);
        }


        /*
        private readonly IBody _body;
        private Matrix4 _basePosition;
        private Matrix4 _footPosition;

        public Matrix4 BasePosition
        {
            get { return _body.Position * _basePosition; }
            set { _basePosition = value; }
        }

        public Matrix4 FootPosition
        {
            get
            {
                Forward();
                return _footPosition;
            }
            set
            {
                _footPosition = value;
                Inverse();
            }
        }

        public readonly Servo CoxaServo = new Servo()
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };

        public readonly Servo FemurServo = new Servo()
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };

        public readonly Servo TibiaServo = new Servo()
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };

        public double CoxaLength { get; set; }
        public double FemurLength { get; set; }
        public double TibiaLength { get; set; }
        
        public Angle CoxaOffset { get; set; }
        public Angle FemurOffset { get; set; }
        public Angle TibiaOffset { get; set; }

        public bool CoxaInvert;
        public bool FemurInvert;
        public bool TibiaInvert;

        public Leg3DOF(IBody body)
        {
            _body = body;
            _body.PositionChanged += Inverse;
            _basePosition = Matrix4.Identity;
            _footPosition = Matrix4.Identity;

            CoxaOffset = 0.0;
            FemurOffset = 0.0;
            TibiaOffset = 0.0;
        }

        public void Forward()
        {
            
        }

        public void Inverse()
        {




            /*
             * Todo: 
             * - Elbow Up + Elbow Down
             * - Reduce Calcs
             * 
             * Jazar Pg. 331
             
            var angle1 = MathsHelper.Atan2(_footPosition.Y - BasePosition.Y, _footPosition.X - BasePosition.X);
            var bd = _footPosition.ToVector3() - (BasePosition * Matrix4.RotateZ(CoxaServo.Angle) * Matrix4.Translate(CoxaLength, 0, 0)).ToVector3();
            //Debug.Write(bd.ToString());
            var angle3 = 2 * MathsHelper.Atan2(
                MathsHelper.Sqrt(MathsHelper.Pow(FemurLength + TibiaLength, 2) - (MathsHelper.Pow(bd.X, 2) + MathsHelper.Pow(bd.Z, 2))),
                MathsHelper.Sqrt(MathsHelper.Pow(bd.X, 2) + MathsHelper.Pow(bd.Z, 2) - MathsHelper.Pow(FemurLength - TibiaLength, 2))
                                   );
            var angle2 = MathsHelper.Atan2(bd.Z, bd.X) + MathsHelper.Atan2(TibiaLength * MathsHelper.Sin(angle3), FemurLength + TibiaLength * MathsHelper.Cos(angle3));

            CoxaServo.Angle = (CoxaInvert ? -1 : 1) * (angle1 + CoxaOffset);
            FemurServo.Angle = (FemurInvert ? -1 : 1) * (angle2 + FemurOffset);
            TibiaServo.Angle = (TibiaInvert ? -1 : 1) * (angle3 + TibiaOffset);
             * 
            //Debug.Write(CoxaServo.Angle.ToString());
            //Debug.Write(FemurServo.Angle.ToString());
            //Debug.Write(TibiaServo.Angle.ToString());
        }
         * */
    }
    public class Leg4DOF : Leg3DOF
    {
        public Leg4DOF(IBody body)
            : base(body)
        {
        }
    }
}
