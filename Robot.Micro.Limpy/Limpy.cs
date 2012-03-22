using System.Threading;
using GHIElectronics.NETMF.FEZ;
using Microsoft.SPOT.Hardware;
using Robot.Micro.Core;
using Robot.Micro.Core.Devices;

using Robot.Micro.Core.Maths;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Messaging.Gateways;
using Robot.Micro.Core.Messaging.Messages;
using Robot.Micro.Core.Reactive;
using Robot.Micro.Core.Serialisation;
using Robot.Micro.Core.Timing;
using Robot.Micro.Core.Kinematics;

namespace Robot.Micro.Limpy
{
    public class Limpy:IRobot
    {
        public IMessageBus Bus { get; private set; }


        public ITimer Timer { get; private set; }
        public bool IsRunning { get; private set; }

        //ISensor list
        readonly LED _led = new LED((Cpu.Pin)FEZ_Pin.Digital.Di13);
        readonly PushButton _button = new PushButton((Cpu.Pin)FEZ_Pin.Interrupt.LDR);

        private readonly SSC32 _ssc = new SSC32("COM4", 115200);
        private readonly Bluetooth _bt = new Bluetooth("COM1", 115200);

        //kinematics
        private IBody _body;
        private ILeg _legLeftFront;
        private ILeg _legLeftMiddle;
        private ILeg _legLeftRear;

        private ILeg _legRightFront;
        private ILeg _legRightMiddle;
        private ILeg _legRightRear;


        public Limpy(IMessageBus bus, ITimer timer)
        {
            Bus = bus;
            Bus.AddGateway(new BluetoothGateway(_bt, new ASCIISerialiser()));
            Timer = timer;
            Bus.Subscribe(obj => Debug.Write(obj.ToString()));

            _button.Pressed += (pushButton, state) =>
            {
                _led.Toggle();
                Bus.Add(new RobotReadyMessage());
            };
        }

        private Servo test = new Servo();

        public void Run()
        {
            _bt.Connect();
            _ssc.Connect();
            Timer.Start();


            testServos();
            /*
            _ssc.AddServo(7, test);
            Bus.Subscribe(obj =>
                              {
                                  test.Angle += Angle.FromDegrees(1);
                                  _ssc.Move();
                              }

                );
            */

            _body = new Body { Position = Matrix4.Identity };
            _legLeftFront = new Leg4DOF(_body)
            {
                BasePosition = Matrix4.Translate(0.0, 0.0, 0.0),
                CoxaLength = 35.0,
                FemurLength = 52.0,
                FemurInvert = true,
                TibiaLength = 48.0,
                TibiaOffset = Angle.FromDegrees(-90.0),
                TibiaInvert = true,
                FootPosition = Matrix4.Translate(35.0 +52.0, 0.0, -48.0),
            };
            //_ssc.AddServo(, _leg.CoxaServo);
            //_ssc.AddServo(1, _leg.FemurServo);
            //_ssc.AddServo(2, _leg.TibiaServo);
            //_ssc.Move();

            //Bus.OfType(typeof(RemoteMessage)).Subscribe(obj => Move(obj as RemoteMessage));
            //Angle test = Angle.FromRadians(MathsHelper.Pi);
            //MathsHelper.Cos(test);


             //_ssc.Connect();



            //setup sensors


            //string test = @"{""DebugMessage"":{""Message"":""Bluetooth Data:w"",""TimeSent"":""01/01/2009 00:17:07""}}""";
            //new JSON().Decode(test, typeof(DebugMessage));
            //set up effectors
            Bus.Add(new RobotReadyMessage());
            MainLoop();
        }

        private void testServos()
        {
            for (short i = 0; i <= 32; i++)
            {
                _ssc.AddServo(i, new Servo());
                _ssc.Move();
                Thread.Sleep(100);
            }
            
    

        }

        void _ssc_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           Debug.WriteLine("ssc data");
        }

        public void Stop()
        {
            
        }
        /*
        private void Move(RemoteMessage remoteMessage)
        {
            switch (remoteMessage.Msg)
            {
                case "w":
                    _legLeftFront.FootPosition *= Matrix4.Translate(0.0, 0.0, 2.0);
                    break;
                case "a":
                    _legLeftFront.FootPosition *= Matrix4.Translate(2.0, 0.0, 0.0);
                    break;
                case "s":
                    _legLeftFront.FootPosition *= Matrix4.Translate(0.0, 0.0, -2.0);
                    break;
                case "d":
                    _legLeftFront.FootPosition *= Matrix4.Translate(-2.0, 0.0, 0.0);
                    break;
                case "q":
                    _legLeftFront.FootPosition *= Matrix4.Translate(0.0, -2.0, 0.0);
                    break;
                case "e":
                    _legLeftFront.FootPosition *= Matrix4.Translate(0.0, 2.0, 0.0);
                    break;
                default:
                    break;
            }

            //_ssc.Move();
        }
        */

        private void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {
            }
        }

        public void Dispose()
        {
            
        }
    }
}
