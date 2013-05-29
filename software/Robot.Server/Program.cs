using System;
using System.Reactive.Linq;
using Robot.Core;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;
using Robot.Core.Timing;
using Robot.Stompy;
namespace Robot.Server
{
    internal class Program
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
    //class Startup
    //{
    //    public void Configuration(IAppBuilder app)
    //    {
    //        // Turn cross domain on 
    //        var config = new HubConfiguration { EnableCrossDomain = true };

    //        // This will map out to http://localhost:8080/signalr by default
    //        app.MapHubs(config);
    //    }
    //}

    //public class MyHub : Hub
    //{
    //    public void Send(string message)
    //    {
    //        Clients.All.addMessage(message);
    //    }
    //}
}
