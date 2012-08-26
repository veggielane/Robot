using System;
using Robot.Core.Extensions;
using Robot.Core.Messaging.Messages;
using Robot.Core.States;

namespace Robot.Stompy.States
{
    class MainState:IState
    {
        private readonly StompyRobot _stompyRobot;
        public string Name { get; private set; }

        public MainState(StompyRobot stompyRobot)
        {
            _stompyRobot = stompyRobot;
            Name = "Main";
        }

        public void Dispose()
        {

        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }
}
