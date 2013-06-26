using System;

namespace Robot.Core
{
    public class BootStrap:IDisposable
    {
        public readonly IRobot _robot;
        public BootStrap(IRobot robot)
        {
            _robot = robot;
            robot.Start();
        }

        public void Dispose()
        {
            _robot.Dispose();
        }

        public static IRobot Robot(IRobot robot)
        {
            return new BootStrap(robot)._robot;
        }
    }
}
