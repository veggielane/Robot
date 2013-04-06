using System;
using System.Reactive.Linq;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;
using Robot.Stompy;


namespace Robot.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var robot = new StompyRobot(new MessageBus()))
            {
                robot.Bus.Messages.OfType<DebugMessage>().Subscribe(Console.WriteLine);
                robot.Start();
                Console.ReadLine();
            }
        }
    }
}
