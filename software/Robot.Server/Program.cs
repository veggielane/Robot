using System;
using System.Collections.Generic;

using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Robot.Core;
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

        //public class ContainerSetup
        //{
        //    private ContainerBuilder _builder;

        //    public IContainer BuildContainer()
        //    {
        //        _builder = new ContainerBuilder();
        //        _builder.RegisterType<StompyRobot>().As<IRobot>();
        //        _builder.RegisterType<MessageBus>().As<IMessageBus>();
        //        return _builder.Build();
        //    }

        //    private static void Main(string[] args)
        //    {

        //        IContainer container = new ContainerSetup().BuildContainer();
        //        using (var robot = container.Resolve<IRobot>())
        //        {
        //            robot.Bus.Messages.OfType<DebugMessage>().Subscribe(Console.WriteLine);
        //            robot.Start();
        //            Console.ReadLine();
        //        }
        //    }
        //}
    }
}
