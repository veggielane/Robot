using System;
using System.Reactive.Linq;
using Robot.Core;
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
            using (var r = BootStrap.Robot(new StompyRobot(new MessageBus(),new Timer())))
            {
                r.Bus.Messages.OfType<DebugMessage>().Subscribe(Console.WriteLine);
                Console.ReadLine();
            }
        }
    }
}
