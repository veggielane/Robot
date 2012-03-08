#if MICRO
namespace Robot.Micro.Core
#else
namespace Robot.Core
#endif
{
    public static class Environment
    {
        public const string NewLine = "\r\n";
    }
}
