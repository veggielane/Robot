using System;
using GHIElectronics.OSH.NETMF.Hardware;
using Robot.Micro.Core;
using Robot.Micro.Core.Devices;
using Robot.Micro.Core.Messaging.Messages;
using Robot.Micro.Core.States;
using Robot.Micro.Core.Reactive;

namespace Robot.Micro.Stompy.States
{
    public class IdleState:IState
    {
        private readonly Stompy _robot;
        public string Name { get; private set; }

        public IdleState(Stompy robot)
        {
            _robot = robot;
            Name = "IdleState";
        }



        private IDisposable _buttonSub;
        private IDisposable _timerSub;
        public void Start()
        {
            _robot.Button.LED = true;
            _timerSub = _robot.Timer.SubSample(10).Subscribe(t => _robot.LED[6] = !_robot.LED[6]);
            _buttonSub = _robot.Button.Where(e => ((ButtonEvent)e).State == ButtonState.Released).Subscribe(e => _robot.Bus.Add(new StateRequest(new MainState(_robot))));
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            _robot.Button.LED = false;
            _robot.LED[6] = false;
            _timerSub.Dispose();
            _buttonSub.Dispose();
        }
    }
}
