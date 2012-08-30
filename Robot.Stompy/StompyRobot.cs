using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Robot.Core;
using Robot.Core.Devices;
using Robot.Core.Kinematics;
using Robot.Core.Maths;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;
using Robot.Core.States;
using Robot.Core.Timing;
using Robot.Stompy.States;

namespace Robot.Stompy
{
    public class StompyRobot:IRobot
    {
        public IMessageBus Bus { get; private set; }
        public ITimer Timer { get; private set; }
        public bool IsRunning { get; private set; }

        public IServoController ServoController { get; private set; }

        public IState CurrentState { get; private set; }
        private readonly Dictionary<Type,IState> _states = new Dictionary<Type, IState>();


        public readonly Servo Servo = new Servo{ Angle = Angle.FromDegrees(30) };

        public IBody Body;

        public readonly ILeg LeftFront;
        public readonly ILeg LeftMiddle;
        public readonly ILeg LeftRear;

        public readonly ILeg RightFront;
        public readonly ILeg RightMiddle;
        public readonly ILeg RightRear;



        public StompyRobot(IMessageBus bus, ITimer timer, IServoController servoController)
        {
            IsRunning = true;
            Bus = bus;
            Bus.OfType<StateRequest>().Subscribe(SetState);
            Timer = timer;

            ServoController = servoController;
            ServoController.Servos.Add(22, Servo);


            Body = new Body();

            LeftFront = new Leg5DOF(Body);
            LeftMiddle = new Leg4DOF(Body);
            LeftRear = new Leg4DOF(Body);

            RightFront = new Leg5DOF(Body);
            RightMiddle = new Leg4DOF(Body);
            RightRear = new Leg4DOF(Body);


            ServoController.Servos.Add(0, (LeftFront as Leg5DOF).RotateServo);
            ServoController.Servos.Add(4, (LeftFront as Leg5DOF).CoxaServo);
            ServoController.Servos.Add(5, (LeftFront as Leg5DOF).FemurServo);
            ServoController.Servos.Add(6, (LeftFront as Leg5DOF).TibiaServo);
            ServoController.Servos.Add(7, (LeftFront as Leg5DOF).TarsServo);

            ServoController.Servos.Add(8, (LeftMiddle as Leg4DOF).CoxaServo);
            ServoController.Servos.Add(9, (LeftMiddle as Leg4DOF).FemurServo);
            ServoController.Servos.Add(10, (LeftMiddle as Leg4DOF).TibiaServo);
            ServoController.Servos.Add(11, (LeftMiddle as Leg4DOF).TarsServo);

            ServoController.Servos.Add(12, (LeftRear as Leg4DOF).CoxaServo);
            ServoController.Servos.Add(13, (LeftRear as Leg4DOF).FemurServo);
            ServoController.Servos.Add(14, (LeftRear as Leg4DOF).TibiaServo);
            ServoController.Servos.Add(15, (LeftRear as Leg4DOF).TarsServo);

            ServoController.Servos.Add(16, (RightFront as Leg5DOF).RotateServo);
            ServoController.Servos.Add(20, (RightFront as Leg5DOF).CoxaServo);
            ServoController.Servos.Add(21, (RightFront as Leg5DOF).FemurServo);
            ServoController.Servos.Add(22, (RightFront as Leg5DOF).TibiaServo);
            ServoController.Servos.Add(23, (RightFront as Leg5DOF).TarsServo);

            ServoController.Servos.Add(24, (RightMiddle as Leg4DOF).CoxaServo);
            ServoController.Servos.Add(25, (RightMiddle as Leg4DOF).FemurServo);
            ServoController.Servos.Add(26, (RightMiddle as Leg4DOF).TibiaServo);
            ServoController.Servos.Add(27, (RightMiddle as Leg4DOF).TarsServo);

            ServoController.Servos.Add(20, (RightRear as Leg4DOF).CoxaServo);
            ServoController.Servos.Add(21, (RightRear as Leg4DOF).FemurServo);
            ServoController.Servos.Add(22, (RightRear as Leg4DOF).TibiaServo);
            ServoController.Servos.Add(23, (RightRear as Leg4DOF).TarsServo);





            AddState(new IdleState(this));
            AddState(new MainState(this));
        }

  

        public void Run()
        {
            Bus.Add(new DebugMessage { Msg = "Robot Starting!" });
            Timer.Start();

            if (!ServoController.Connect())
            {
                Bus.Add(new DebugMessage { Msg = "Servo Controller Failed To Connect" });
            }

            Bus.Add(StateRequest.Create<IdleState>());
        }

        public void Stop()
        {

        }

        public void Enable()
        {
 
        }

        public void Disable()
        {

        }

        public void Dispose()
        {

        }

        private void AddState(IState state)
        {
            _states.Add(state.GetType(),state);
        }


        private void SetState(StateRequest stateRequest)
        {
            IState state = _states[stateRequest.StateType];

            if (CurrentState != null)
            {
                Bus.Add(new StateStopping(CurrentState));
                CurrentState.Stop();
            }

            CurrentState = state;
            Bus.Add(new StateStarting(CurrentState));
            CurrentState.Start();
        }
    }
}
