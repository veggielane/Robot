using System;
using Robot.Core.Extensions;
using Robot.Core.Messaging.Messages;
using Robot.Core.States;

namespace Robot.Stompy.States
{
    class IdleState:IState
    {
        private readonly StompyRobot _stompyRobot;
        public string Name { get; private set; }

        public IdleState(StompyRobot stompyRobot)
        {
            _stompyRobot = stompyRobot;
            Name = "Idle";
        }

        public void Dispose()
        {

        }

        public void Start()
        {
            _stompyRobot.Timer.SubSample(1000).Subscribe(t => _stompyRobot.Bus.Add(StateRequest.Create<MainState>()));
        }

        public void Stop()
        {

        }
    }
}
