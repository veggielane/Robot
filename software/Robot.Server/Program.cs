using System;
using System.IO.Ports;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using Robot.Core;
using Robot.Core.Devices;
using Robot.Core.Maths;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;
using Robot.Core.Timing;
using Robot.Stompy;
namespace Robot.Server
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Server starting ...");

            //
            //

            //Console.WriteLine("rad: " + a.Radians.ToString());

            //Console.WriteLine("pulse: " + (int)a.Radians.Map(-MathsHelper.PiOverTwo, MathsHelper.PiOverTwo, 600.0, 2400.0));
            //var sp = new SerialPort("/dev/ttyAMA0", 115200, Parity.None, 8, StopBits.One);
            //sp.Open();

            //var test = "testing";

            //sp.Write(Encoding.UTF8.GetBytes(test),0,test.Length);
            //sp.Close();

            //using (var r = BootStrap.Robot(new StompyRobot(new MessageBus(),new Timer())))
            //{
            //    r.Bus.Messages.Subscribe(Console.WriteLine);
            //    Console.ReadLine();
            //}




            var ssc = new SSC32("/dev/ttyAMA0");
            //var ssc = new SSC32("/dev/ttyUSB0");
            ssc.Connect();
            var servo = new Servo { Angle = Angle.FromDegrees(0) };
            var servo1 = new Servo { Angle = Angle.FromDegrees(0) };
            ssc.Servos.Add(0, servo);
            ssc.Servos.Add(1, servo1);

            ssc.Update();

            int time = 250;
            while(true)
            {

                Thread.Sleep(time);
                servo.Angle = Angle.FromDegrees(45);
                servo1.Angle = Angle.FromDegrees(45);
                ssc.Update(null, time);

                Thread.Sleep(time);
                servo.Angle = Angle.FromDegrees(-45);
                servo1.Angle = Angle.FromDegrees(-45);
                ssc.Update(null, time);
            }


            //ssc.REPL();
            //Console.ReadLine();
        }


    }
}
