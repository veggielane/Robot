using GHIElectronics.OSH.NETMF.Hardware;
using Robot.Micro.Core;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Kinematics;
using Robot.Micro.Core.Maths;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Messaging.Messages;
using Robot.Micro.Core.Timing;
using Robot.Micro.Core.States;
using Robot.Micro.Stompy.States;
using Robot.Micro.Core.Reactive;

namespace Robot.Micro.Stompy
{
    public class Stompy:IRobot
    {
        public IMessageBus Bus { get; private set; }

        public IState CurrentState { get; private set; }

        public ITimer Timer { get; private set; }
        public bool IsRunning { get; private set; }

        private readonly Bluetooth _bluetooth = new Bluetooth("COM3", 115200);
        public readonly SSC32 SSC32 = new SSC32("COM1", 115200);

        public LED7R LED = new LED7R(new[] { FEZHydra.Pin.PB8, FEZHydra.Pin.PB9, FEZHydra.Pin.PB12, FEZHydra.Pin.PB13, FEZHydra.Pin.PA26, FEZHydra.Pin.PA25, FEZHydra.Pin.PA27 });
        public Button Button = new Button(FEZHydra.Pin.PC9, FEZHydra.Pin.PC10);

        //kinematics
        private readonly IBody _body = new Body();

        private ILeg _legLeftFront;
        private ILeg _legLeftMiddle;
        private ILeg _legLeftRear;

        private ILeg _legRightFront;
        private ILeg _legRightMiddle;
        private ILeg _legRightRear;


        private readonly Servo _leftRotateServo = new Servo
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };

        private readonly Servo _rightRotateServo = new Servo
        {
            Min = Angle.FromDegrees(-90),
            Max = Angle.FromDegrees(90),
            Angle = 0.0
        };

        private readonly Servo _leftFrontExtra = new Servo{Angle = 0.0};
        private readonly Servo _leftMiddleExtra = new Servo { Angle = 0.0 };
        private readonly Servo _leftRearExtra = new Servo { Angle = 0.0 };
        private readonly Servo _rightFrontExtra = new Servo { Angle = 0.0 };
        private readonly Servo _rightMiddleExtra = new Servo { Angle = 0.0 };
        private readonly Servo _rightRearExtra = new Servo { Angle = 0.0 };


        public Stompy(IMessageBus bus, ITimer timer)
        {
            IsRunning = true;
            Bus = bus;
            Timer = timer;
            Bus.Subscribe(obj => Debug.Write(obj.ToString()));
            Bus.OfType(typeof(StateRequest)).Subscribe(m => SetState(((StateRequest)m).State));


            InitLegs();
        }

        private void SetState(IState state)
        {
            if(CurrentState != null)
            {
                Bus.Add(new DebugMessage { Msg = "Stopping State: " + CurrentState.Name });
                CurrentState.Stop();
            }
            CurrentState = state;
            Bus.Add(new DebugMessage { Msg = "Starting State: " + CurrentState.Name });
            CurrentState.Start();
        }

        public void Run()
        {
            Bus.Add(new DebugMessage{Msg = "Robot Starting"});
            Timer.Start();
            _bluetooth.Open();
            SSC32.Open();
            SetState(new IdleState(this));
            Bus.Add(new RobotReadyMessage());
        }



        public void Dispose()
        {
            SSC32.Dispose();
        }

        public void Stop()
        {
            Dispose();
        }

        private void InitLegs()
        {
            _legLeftFront = new Leg3DOF(_body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 35.0,
                FemurLength = 52.0,
                FemurInvert = true,
                TibiaLength = 48.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                TibiaInvert = true,
                FootPosition = Matrix4.Translate(35.0 + 52.0, 0.0, -48.0),
            };

            _legLeftMiddle = new Leg3DOF(_body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 35.0,
                FemurLength = 52.0,
                FemurInvert = true,
                TibiaLength = 48.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                TibiaInvert = true,
                FootPosition = Matrix4.Translate(35.0 + 52.0, 0.0, -48.0),
            };

            _legLeftRear = new Leg3DOF(_body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 35.0,
                FemurLength = 52.0,
                FemurInvert = true,
                TibiaLength = 48.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                TibiaInvert = true,
                FootPosition = Matrix4.Translate(35.0 + 52.0, 0.0, -48.0),
            };

            _legRightFront = new Leg3DOF(_body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 35.0,
                FemurLength = 52.0,
                FemurInvert = true,
                TibiaLength = 48.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                TibiaInvert = true,
                FootPosition = Matrix4.Translate(35.0 + 52.0, 0.0, -48.0),
            };

            _legRightMiddle = new Leg3DOF(_body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 35.0,
                FemurLength = 52.0,
                FemurInvert = true,
                TibiaLength = 48.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                TibiaInvert = true,
                FootPosition = Matrix4.Translate(35.0 + 52.0, 0.0, -48.0),
            };

            _legRightRear = new Leg3DOF(_body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 35.0,
                FemurLength = 52.0,
                FemurInvert = true,
                TibiaLength = 48.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                TibiaInvert = true,
                FootPosition = Matrix4.Translate(35.0 + 52.0, 0.0, -48.0),
            };

            SSC32.AddServo(0, _leftRotateServo);
            SSC32.AddServo(16, _rightRotateServo);

            SSC32.AddServo(6, _leftFrontExtra);
            SSC32.AddServo(10, _leftMiddleExtra);
            SSC32.AddServo(14, _leftRearExtra);
            SSC32.AddServo(22, _rightFrontExtra);
            SSC32.AddServo(26, _rightMiddleExtra);
            SSC32.AddServo(30, _rightRearExtra);
        }
    }
}
