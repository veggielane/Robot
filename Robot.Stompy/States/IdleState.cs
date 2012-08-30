using System;
using System.Reactive.Linq;
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
            _stompyRobot.Bus.Add(new DebugMessage("tick start"));

            //_stompyRobot.Timer.Delay(new TimeSpan(0, 0, 2), () => Console.WriteLine("test"));
            //_stompyRobot.Timer.SubSample().Subscribe();
            //_stompyRobot.Bus.Add( StateRequest.Create<MainState>()
            _stompyRobot.Timer.SubSample(50).Skip(1).Take(1).Subscribe(t =>Console.WriteLine(3));
        }

        public void Stop()
        {

        }
    }
}
