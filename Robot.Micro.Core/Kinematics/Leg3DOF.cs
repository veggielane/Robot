using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Kinematics
{
    public class Leg3DOF : ILeg
    {
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

        public bool CoxaInvert = false;
        public bool FemurInvert = false;
        public bool TibiaInvert = false;

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
             */
            var angle1 = MathsHelper.Atan2(_footPosition.Y - BasePosition.Y, _footPosition.X - BasePosition.X);
            var bd = _footPosition.ToVector3() - (BasePosition * Matrix4.RotateZ(CoxaServo.Angle) * Matrix4.Translate(CoxaLength, 0, 0)).ToVector3();
            //Debug.Print(bd.ToString());
            var angle3 = 2 * MathsHelper.Atan2(
                MathsHelper.Sqrt(MathsHelper.Pow(FemurLength + TibiaLength, 2) - (MathsHelper.Pow(bd.X, 2) + MathsHelper.Pow(bd.Z, 2))),
                MathsHelper.Sqrt(MathsHelper.Pow(bd.X, 2) + MathsHelper.Pow(bd.Z, 2) - MathsHelper.Pow(FemurLength - TibiaLength, 2))
                                   );
            var angle2 = MathsHelper.Atan2(bd.Z, bd.X) + MathsHelper.Atan2(TibiaLength * MathsHelper.Sin(angle3), FemurLength + TibiaLength * MathsHelper.Cos(angle3));



            CoxaServo.Angle = (CoxaInvert ? -1 : 1) * (angle1 + CoxaOffset);
            FemurServo.Angle = (FemurInvert ? -1 : 1) * (angle2 + FemurOffset);
            TibiaServo.Angle = (TibiaInvert ? -1 : 1) * (angle3 + TibiaOffset);
            
            Debug.Print(CoxaServo.Angle.ToString());
            Debug.Print(FemurServo.Angle.ToString());
            Debug.Print(TibiaServo.Angle.ToString());
            /** 
             * 
            Angle Theta1;
            Angle Theta2;
            Double E = _footPosition[1, 4] - _basePosition[1, 4];
            Double D = _footPosition[3, 4] - _basePosition[3, 4];

            Theta2 = 2*MathsHelper.Atan2(
                MathsHelper.Sqrt(MathsHelper.Pow(FemurLength + TibiaLength, 2) - (MathsHelper.Pow(E, 2) + MathsHelper.Pow(D, 2))), 
                MathsHelper.Sqrt(MathsHelper.Pow(E, 2) + MathsHelper.Pow(D, 2) - MathsHelper.Pow(FemurLength - TibiaLength, 2))
            );
            Debug.Print(Theta2.ToString());
            //Theta1 = 

            Theta1 = MathsHelper.Atan2(D, E) + MathsHelper.Atan2(TibiaLength * MathsHelper.Sin(Theta2), FemurLength + TibiaLength * MathsHelper.Cos(Theta2));
            Debug.Print(Theta1.ToString());
 
            

            //Hip H
            Debug.Print(_footPosition.ToString());
            Debug.Print(_basePosition.ToString());
            CoxaServo.Angle = MathsHelper.Atan2(_footPosition[2, 4] - _basePosition[2, 4], _footPosition[1, 4] - _basePosition[1, 4]);
            Debug.Print(CoxaServo.Angle.ToString());

            Debug.Print("A:");
            Vect3 A = _basePosition.ToVector3();
            Debug.Print(A.ToString());
            Debug.Print("B:");
            Vect3 B = (_basePosition * Matrix4.RotateZ(CoxaServo.Angle) * Matrix4.Translate(CoxaLength, 0, 0)).ToVector3();
            Debug.Print(B.ToString());
            Debug.Print(B.Length.ToString());


            Vect3 D = _footPosition.ToVector3();
            Debug.Print("D:");
            Debug.Print(D.ToString());

            Vect3 BD = D - B;


            //Hip V
            FemurServo.Angle = MathsHelper.Atan2(BD.Z, MathsHelper.Sqrt(MathsHelper.Pow(BD.X, 2.0) + MathsHelper.Pow(BD.Y, 2.0))) + MathsHelper.Acos((MathsHelper.Pow(FemurLength, 2.0) - MathsHelper.Pow(TibiaLength, 2.0) + MathsHelper.Pow(BD.Length, 2.0)) / (2 * FemurLength * BD.Length));
            Debug.Print(FemurServo.Angle.ToString());
            //Double q1 = 

             //
            // Knee
            TibiaServo.Angle = MathsHelper.Acos((MathsHelper.Pow(FemurLength, 2.0) + MathsHelper.Pow(TibiaLength, 2.0) - MathsHelper.Pow(BD.Length, 2.0)) / (2 * FemurLength * TibiaLength));
            Debug.Print(TibiaServo.Angle.ToString());*/
        }
    }
}
