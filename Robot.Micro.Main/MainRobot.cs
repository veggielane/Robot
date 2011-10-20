using GHIElectronics.NETMF.FEZ;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Robot.Micro.Core;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Devices.CommunicationChannels;
using Robot.Micro.Core.Maths;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Messaging.Messages;
using Robot.Micro.Core.Timing;

namespace Robot.Micro.Main
{
    public class MainRobot:IRobot
    {
        public MessageBus Bus { get; private set; }

        public CommunicationChannels Channels { get; private set; }

        public ITimer Timer { get; private set; }
        public bool IsRunning { get; private set; }

        //ISensor list

        readonly LED _led = new LED((Cpu.Pin)FEZ_Pin.Digital.LED);
        readonly PushButton _button = new PushButton((Cpu.Pin)FEZ_Pin.Interrupt.LDR);

        private readonly SSC32 _ssc = new SSC32("COM4", 115200);
        private readonly Bluetooth _bt = new Bluetooth("COM1", 115200);

        readonly Servo _servo = new Servo()
        {
            Min = Angle.FromDegrees(-45),
            Max = Angle.FromDegrees(45),
            Angle = Angle.FromDegrees(0),
        };

        public MainRobot()
        {
            Bus = new MessageBus();
            Bus.Subscribe(obj => Debug.Print(obj.ToString()));
            Channels = new CommunicationChannels(Bus);
            Timer = new AsyncObservableTimer();
            _button.Pressed += (pushButton, state) =>
            {
                _led.Toggle();
                Bus.Add(new RobotReadyMessage());
                _servo.Angle += Angle.FromDegrees(1);
                _ssc.Move();
            };
        }

        public void Run()
        {
            Timer.Start();
            Channels.Add(_bt);
            _ssc.Connect();

     

            _ssc.AddServo(0, _servo);
            //_servo.Angle = Angle.FromDegrees(90);
            _ssc.Move();

            //setup sensors


            //string test = @"{""DebugMessage"":{""Message"":""Bluetooth Data:w"",""TimeSent"":""01/01/2009 00:17:07""}}""";
            //new JSON().Decode(test, typeof(DebugMessage));
            //set up effectors
            Bus.Add(new RobotReadyMessage());
            //MainLoop();
        }

        private void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {

            }
        }
    }
}