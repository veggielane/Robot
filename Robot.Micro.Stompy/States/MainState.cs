using System;
using Microsoft.SPOT;
using Robot.Micro.Core.Devices;
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

        public void Start()
        {
            _timerSub = _robot.Timer.Subscribe(t => Animate());
            _robot.SSC32.Move();



        }

        public void Stop()
        {

            _robot.SSC32.FreeServos();
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
