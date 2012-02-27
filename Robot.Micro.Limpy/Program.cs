using System.Threading;
using Microsoft.SPOT;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Timing;
namespace Robot.Micro.Limpy
{
    public class Program
    {
        public static void Main()
        {
            Debug.GC(true);
            Debug.EnableGCMessages(true);
            using (var robot = new Limpy(new MessageBus(), new AsyncObservableTimer()))
            {
                robot.Run();
            }
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
