using System;
using System.Collections;
using System.Reflection;
using System.Threading;
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
                Debug.Write("Found: " + classtype);
                foreach (var method in classtype.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (method.Name.Length >= 4 && method.Name.Substring(0, 4) == "Test")
                        ht.Add(method.Name, method);
                }
            }
            
            foreach (DictionaryEntry entry in ht)
            {
                Exception exception = null;
                Debug.Write("--------------------------");
                Debug.Write("Running: " + entry.Key);
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
                        Debug.Write("Result: FAIL");
                        Debug.Write("Reason: " + exception.Message);
                    }
                    else
                    {
                        Debug.Write("Result: PASS");
                    }
                }
            }
            Debug.Write("---------------------------");
            Debug.Write("---------------------------");
            Debug.Write("Passed: " + countPass);
            Debug.Write("Failed: " + countFail);
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