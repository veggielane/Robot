#if MICRO
namespace Robot.Micro.Core
#else
namespace Robot.Core
#endif
{
    public static class Debug
    {
        public static void Write(string msg)
        {
#if MICRO
            Microsoft.SPOT.Debug.Print(msg);
#else
            System.Diagnostics.Debug.WriteLine(msg);
#endif
        }
        public static void WriteLine(string msg)
        {
            Write(msg + Environment.NewLine);
        }

    }
}
