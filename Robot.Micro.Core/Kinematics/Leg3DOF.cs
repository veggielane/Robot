using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Maths;

namespace Robot.Micro.Core.Kinematics
{
    public class Leg3DOF : ILeg
    {
        private IBody _body;
        private Matrix4 _basePosition;

        public Matrix4 BasePosition { get; set; }

        private Matrix4 _footPosition;
        public Matrix4 FootPosition
        {
            get
            {
                return _footPosition;
            }
            set
            {
                _footPosition = value;
            }
        }

        public Servo CoxaServo = new Servo()
        {
            Min = Angle.FromDegrees(-45),
            Max = Angle.FromDegrees(45),
            Angle = 0.0
        };

        public Servo FemurServo = new Servo()
        {
            Min = Angle.FromDegrees(-45),
            Max = Angle.FromDegrees(45),
            Angle = 0.0
        };

        public Servo TibiaServo = new Servo()
        {
            Min = Angle.FromDegrees(-45),
            Max = Angle.FromDegrees(45),
            Angle = 0.0
        };

        public double CoxaLength { get; set; }
        public double FemurLength { get; set; }
        public double TibiaLength { get; set; }

        public Leg3DOF(IBody body)
        {
            _body = body;
            _basePosition = Matrix4.Identity();
            _footPosition = Matrix4.Identity();
        }

        public void Forward()
        {
            
        }

        public void Inverse()
        {
            CoxaServo.Angle = MathsHelper.Atan2(_footPosition[2, 4] - _basePosition[2, 4], _footPosition[2, 1] - _basePosition[2, 1]);

           // FemurServo.Angle = MathsHelper.Atan2(BtoD.Pz, MathsHelper.Sqrt(MathsHelper.Pow(BtoD.Px, 2.0) + MathsHelper.Pow(BtoD.Py, 2.0))) + MathsHelper.Acos((MathsHelper.Pow(L1, 2.0) - MathsHelper.Pow(L2, 2.0) + MathsHelper.Pow(BtoD.Mag(), 2.0)) / (2 * L1 * BtoD.Mag()));

            TibiaServo.Angle = 0.0;
        }
    }
}
