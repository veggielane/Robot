using System;
using Robot.Core.Extensions;
using Robot.Core.Messaging.Messages;
using Robot.Core.States;

namespace Robot.Stompy.States
{
    class MainState:IState
    {
        private readonly StompyRobot _robot;
        public string Name { get; private set; }

        public MainState(StompyRobot robot)
        {
            _robot = robot;
            Name = "Main";
        }

        public void Dispose()
        {

        }

        public void Start()
        {
            _robot.Bus.Add(new DebugMessage("test"));
            _robot.Servo.Angle = -30.0;
            _robot.ServoController.Update();
        }

        public void Stop()
        {

        }
    }
}
