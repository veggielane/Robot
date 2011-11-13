using System;
using System.Collections;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
namespace Robot.Micro.Core.Test
{
    public class Program
    {
        public static void Main()
        {
            var ht = new Hashtable();
            int countPass = 0;
            int countFail = 0;

            foreach (Type classtype in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (classtype.Name.Length < 5 || classtype.Name.Substring(0, 5) != "Tests") continue;
                Debug.Print("Found: " + classtype);
                foreach (var method in classtype.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (method.Name.Length >= 4 && method.Name.Substring(0, 4) == "Test")
                        ht.Add(method.Name, method);
                }
            }
            
            foreach (DictionaryEntry entry in ht)
            {
                Exception exception = null;
                Debug.Print("---------------------------");
                Debug.Print("Running: " + entry.Key);
                try
                {
                    ((MethodInfo) entry.Value).Invoke(null, null);
                    countPass++;
                }
                catch (Exception ex)
                {
                    countFail++;
                    exception = ex;
                }
                finally
                {
                    if (exception != null)
                    {
                        Debug.Print("Result: FAIL");
                        Debug.Print("Reason: " + exception.Message);
                    }
                    else
                    {
                        Debug.Print("Result: PASS");
                    }
                }
            }
            Debug.Print("---------------------------");
            Debug.Print("---------------------------");
            Debug.Print("Passed: " + countPass);
            Debug.Print("Failed: " + countFail);
            /*
            var app = new Application();
            var window = new Window
                             {
                                 Height = SystemMetrics.ScreenHeight,
                                 Width = SystemMetrics.ScreenWidth,
                                 Background = new SolidColorBrush(Colors.Green),
                                 Visibility = Visibility.Visible
                             };

            if (countFail > 0)
            {
                window.Background = new SolidColorBrush(Colors.Red);
            }

            app.Run(window);*/
            Thread.Sleep(Timeout.Infinite);
        }
    }
}