using System;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Robot.Micro.Core.Messaging;
using Robot.Micro.Core.Timing;

//using GHIElectronics.NETMF.FEZ;

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
            /*
             * var bt = new Bluetooth("COM1", 115200);
            bt.Open();
            bt.Write("Testing" + Convert.ToChar(13));
            bt.Messages.Subscribe(obj => Debug.Print((string)obj));
            Debug.GC(true);

            var bt = new Bluetooth("COM1", 115200);
            bt.Open();
            bt.Write("testing");
            bt.Messages.Subscribe(obj => Debug.Print((string)obj));


            
            var led = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, true);

            var bus = new MessageBus();

            var timer = new AsyncObservableTimer();
            timer.SubSample(10)Subscribe(obj => led.Write(!led.Read()));

            bus.Subscribe(item => Debug.Print("A:" + item.ToString()));
            bus.SubSample(10).Subscribe(new Observer(item => Debug.Print("B:" + item.ToString())));

            var i = 0;

            timer.Subscribe(new Observer(tick => bus.Add(i++)));
            timer.Start();
            Debug.Print("test");
            Thread.Sleep(100000);
            timer.Stop();
            new Task(() =>
            {
                while (true)
                {
                    bus.Add("test");
                    Thread.Sleep(1000);
                }

            }).Start();
                        var test = new SSC32("COM1", 115200);

                        if (!test.Connect()) return;
                        test.Execute();
                        test.Write("#0 P1500 S750");
                        test.Execute();
                        test.Write("#1 P1500 S750");
                        test.Execute();
                        test.Write("#2 P1500 S750");
                        test.Execute();
                        test.Write("#3 P1500 S750");
                        test.Execute();
                        test.Write("#4 P1500 S750");
                        test.Execute();
                        test.Write("#5 P1500 S750");
                        test.Execute();
            
                        Debug.Print("Connected");

                        var a = new[] { 1, 2, 3, 4, 6, 8, 9, 9, 9 };

                        var n = a.Any(item => ((int)item) == 9);
                        var m = a.All(item => ((int)item) == 9);
                        var t = a.Where(v => (int)v % 2 == 0).Count(o => true);
                        Debug.Print(n + " " + m);
                        Debug.Print("count " + t);
                         */
            Thread.Sleep(Timeout.Infinite);
        }

    }
}
