using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using Robot.Core.Devices;
using Robot.Core.Maths;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;
using Robot.Core.Timing;
using Robot.Stompy;

namespace Robot.Raspberry.Stompy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            var lcd = new TextStar("/dev/ttyAMA0");
            lcd.Open();
            lcd.Clear();

            var ssc = new SSC32("/dev/ttyUSB0");
            var servo = new Servo { Angle = Angle.FromDegrees(20) };

            ssc.AddServo(23, servo);
            ssc.Open();

            for (int i = 0; i < 10; i++)
            {
                servo.Angle = -servo.Angle;
                ssc.Move();
                Thread.Sleep(100);
            }




            using (var stompy = new StompyRobot(new MessageBus(), new AsyncObservableTimer()))
            {
                stompy.Bus.OfType<DebugMessage>().Subscribe(Console.WriteLine);
                stompy.Bus.OfType<DebugMessage>().Subscribe(m =>
                {
                    lcd.Clear();
                    lcd.Write(m.Msg);
                });
                stompy.Run();
                while (stompy.IsRunning)
                {

                }
            }





            /*
            TextStar lcd = new TextStar("/dev/ttyAMA0"); 
            lcd.Open();
            lcd.Clear();

            lcd.SetCursorStyle(TextStar.CursorStyle.SolidBlock);
            lcd.Write("hello!!!");
            lcd.MoveCursor(TextStar.CursorControl.Down);
            lcd.Close();

            var ssc = new SSC32("/dev/ttyUSB0");
            var servo = new Servo {Angle = Angle.FromDegrees(20)};

            ssc.AddServo(23, servo);
            ssc.Open();



            for (int i = 0; i < 10; i++)
            {
                servo.Angle = -servo.Angle;
                ssc.Move();
                Thread.Sleep(100);
            }
            */
            
            //23
            //Console.ReadLine();
        }
    }
}
