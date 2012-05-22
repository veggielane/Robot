using System;
using System.Threading;
using GHIElectronics.OSH.NETMF.Hardware;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Maths;
using Robot.Micro.Core.Messaging.Messages;
using Robot.Micro.Core.Reactive;
using Robot.Micro.Core.States;

namespace Robot.Micro.Stompy.States
{
    public class MainState : IState
    {
        private readonly Stompy _robot;
        public string Name { get; private set; }



        public MainState(Stompy robot)
        {
            _robot = robot;
            Name = "MainState";
        }

        private IDisposable _buttonSub;
        private IDisposable _joybuttonSub;
        private IDisposable _joySub;

        private double z = 0;
        public void Start()
        {
            _timerSub = _robot.Timer.Subscribe(t => Animate());

            //timer.Delay(1000,() => 
            //var sequence = timer.Sequence(
            //new Event(
            //_robot.SSC32.Move();
            //_robot.Timer.Delay(new TimeSpan(0, 0, 1, 0),() => Debug.Print("test"));
            _robot.Enable();
            _buttonSub = _robot.Button.Where(e => ((ButtonEvent)e).State == ButtonState.Released).Subscribe(e => _robot.Bus.Add(new StateRequest(new IdleState(_robot))));

            _joybuttonSub = _robot.joy.Subscribe(e =>
            {
               z -= 1;
           });

            _joySub = _robot.Timer.Subscribe(o =>
            {
                var x = _robot.joy.Position.X.Map(0.0, 1.0, -50.0, 50.0);
                if (x < 0.5 && x > -0.5)
                    x = 0;

                var y = _robot.joy.Position.Y.Map(0.0, 1.0, -50.0, 50.0);
                if (y < 0.5 && y > -0.5)
                    y = 0;

                _robot.LegLeftFront.FootOffset = new Vect3(x, y, z);
                _robot.SSC32.Move();
            });
     
        }

        public void Stop()
        {
            if(_buttonSub != null)_buttonSub.Dispose();
            if (_joybuttonSub != null) _joybuttonSub.Dispose();
            if (_joySub != null) _joySub.Dispose();
            Thread.Sleep(100);
            _robot.Disable();
        }

#region Animate Start
        private IDisposable _timerSub;
        private int _i;
        private void Animate()
        {
            if (_i >= 0 && _i < 6)
            {
                _robot.LED[_i++] = true;
            }
            else
            {
                _timerSub.Dispose();
            }
        }
#endregion

        public void Dispose()
        {
            //_robot.SSC32.FreeServos();
        }
    }
}
