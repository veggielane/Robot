using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using Robot.Core;
using Robot.Core.FiniteStateMachine;
using Robot.Core.FiniteStateMachine.States;
using Robot.Core.Messaging.Messages;

namespace Robot.Stompy.States
{
    public class MovingState:IState 
    {
        private readonly StompyRobot _robot;
        public string Name { get; private set; }



        public MovingState(StompyRobot stompyRobot)
        {
            _robot = stompyRobot;
            Name = "Moving State";
        }

        private IDisposable _timer;
        public void Start()
        {
            Console.WriteLine("Starting State: " + Name);
            _timer = _robot.Timer.Ticks.Subscribe(t =>
            {
                //Console.WriteLine(DateTime.Now);
                //Bus.Add(new DebugMessage("Kinematic Tick"));
                //_kinematicEngine.Inverse();
            });
            //Thread.Sleep(1000);
            //_robot.Bus.Add(new StateMachineCommandMessage(typeof(StopCommand)));
            //_timer = _robot.Timer.Ticks.Take(1).SubSample(100).Subscribe(t => ));
        }

        public void Stop()
        {
            Console.WriteLine("Stopping State: " + Name);

        }
    }
}
