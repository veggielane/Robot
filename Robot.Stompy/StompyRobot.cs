using System;
using System.Collections;
using System.Collections.Generic;
using System.Reactive.Linq;
using Robot.Core;
using Robot.Core.Devices;
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

        public Servo servo1 = new Servo();
        public Servo servo2 = new Servo() { Angle = Angle.FromDegrees(30) };
        public Servo servo3 = new Servo();


        public StompyRobot(IMessageBus bus, ITimer timer, IServoController servoController)
        {
            IsRunning = true;
            Bus = bus;
            Bus.OfType<StateRequest>().Subscribe(SetState);
            Timer = timer;

            ServoController = servoController;
            ServoController.Servos.Add(22, servo2);


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
