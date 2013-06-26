using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Core;
using Robot.Core.Devices;
using Robot.Core.FiniteStateMachine.States;
using Robot.Core.Kinematics;
using Robot.Core.Maths;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;
using Robot.Core.Timing;
using Robot.Stompy.States;

namespace Robot.Stompy
{
    public class StompyRobot:BaseRobot
    {
        private readonly IKinematicEngine _kinematicEngine;
        private readonly IBody _body;

        public readonly Leg3DOF LeftFront;
        public readonly Leg3DOF LeftMiddle;
        public readonly Leg3DOF LeftRear;
        public readonly Leg3DOF RightFront;
        public readonly Leg3DOF RightMiddle;
        public readonly Leg3DOF RightRear;

        public StompyRobot(IMessageBus bus, ITimer timer)
            : base(bus,timer)
        {
            _body = new Body();
            LeftFront = new Leg3DOF(Matrix4.Identity) {FootPosition = new Vector3(10, 10, 10)};
            LeftMiddle = new Leg3DOF(Matrix4.Identity) { FootPosition = new Vector3(10, 10, 10) };
            LeftRear = new Leg3DOF(Matrix4.Identity) { FootPosition = new Vector3(10, 10, 10) };
            RightFront = new Leg3DOF(Matrix4.Identity) { FootPosition = new Vector3(10, 10, 10) };
            RightMiddle = new Leg3DOF(Matrix4.Identity) { FootPosition = new Vector3(10, 10, 10) };
            RightRear = new Leg3DOF(Matrix4.Identity) { FootPosition = new Vector3(10, 10, 10) };

            _kinematicEngine = new KinematicEngine(_body, LeftFront, LeftMiddle, LeftRear, RightFront, RightMiddle, RightRear);

            StateMachine.AddState(new MovingState(this));

            StateMachine.AddTransition<IdleState, StartCommand, MovingState>();
            StateMachine.AddTransition<MovingState, StopCommand, IdleState>();

            Timer.Ticks.Subscribe(t =>
                {
                    //Console.WriteLine(DateTime.Now + " - " + Timer.LastTickTime.TimeElapsed);
                    //Bus.Add(new DebugMessage("Kinematic Tick"));
                    //_kinematicEngine.Inverse();
                });
        }

        public override void Start()
        {

            Bus.Add(new StateMachineCommandMessage(typeof(StartCommand)));
        }

        public override void Stop()
        {

        }

        public void Dispose()
        {
            Stop();
        }
    }

    
}
