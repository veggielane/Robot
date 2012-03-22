using System;
using System.Threading;
using Microsoft.SPOT;
//using GHIElectronics.OSH.NETMF.Hardware; // <<< This is the only needed change
namespace Robot.Micro.Stompy
{
   public class Program
    {
       public static void Main()
       {
           using(var stompy = new Stompy())
           {
               Debug.Print("Starting Stompy");
               //stompy.Run();
           }
           Thread.Sleep(Timeout.Infinite);
       }


       /*
       LED7R led;
        public static void Main()
        {
            Mainboard = new GHIElectronics.Gadgeteer.FEZHydra();
            var program = new Program();
            program.InitializeModules();
            program.Run();
        }

        private void InitializeModules()
        {
            led = new LED7R(3);
            //
            var skt = Socket.GetSocket(4, false, null, null);
            Debug.Print(skt.SerialPortName);

            led.Animate(100, true, true, true);
            led.TurnLightOn(7);



            //new Gadgeteer.Interfaces.Serial(Socket.GetSocket(4,true,))



            Debug.Print("helllllo");
        }*/
    }

}
            //var stompy = new Stompy();
            //stompy.Initialize();