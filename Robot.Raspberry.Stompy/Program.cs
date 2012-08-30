using System;
using Robot.Core.Devices;
using Robot.Core.Messaging;
using Robot.Core.Timing;
using Robot.Stompy;

namespace Robot.Raspberry.Stompy
{
    class Program
    {
        static void Main(string[] args)
        {
           // var lcd = new TextStar("/dev/ttyAMA0");
            //lcd.Open();
             using (var stompy = new StompyRobot(new MessageBus(), new AsyncObservableTimer(), new SSC32("/dev/ttyUSB0")))
             {
                stompy.Bus.Subscribe(Console.WriteLine);
                //stompy.Bus.OfType<DebugMessage>().Subscribe(lcd.Display);
                stompy.Run();
            }
        }
    }
}
