using System.Threading;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Timing;
namespace Robot.Micro.Stompy
{
   public class Program
    {
       public static void Main()
       {
           using (var stompy = new Stompy(new MessageBus(), new AsyncObservableTimer()))
           {
               stompy.Run();
               while (stompy.IsRunning)
               {
                   
               }
           }
           Thread.Sleep(Timeout.Infinite);
       }
    }
}
