using System;
using GHIElectronics.OSH.NETMF.Hardware;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Maths;
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

            _robot.Timer.Subscribe(t =>
                                       {
                                           var x = robot.joy.Position.X.Map(0.0, 1.0, -45.0, 45.0);
                                           if(x < 0.5 && x > -0.5)
                                               x = 0;
                                           _robot.TestServo.Angle = x;
        _robot.SSC32.Move();
                                                     });

            _robot.Timer.Subscribe(t => Debug.Print(robot.joy.Position.X.Map(0.0, 1.0, -45.0, 45.0).ToString()));
        }

        public void Start()
        {
            _timerSub = _robot.Timer.Subscribe(t => Animate());

            //timer.Delay(1000,() => 
            //var sequence = timer.Sequence(
            //new Event(
            //_robot.SSC32.Move();

        }

        public void temp(TimeSpan d)
        {


        }

        public void Stop()
        {

    
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
