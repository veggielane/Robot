using GHIElectronics.OSH.NETMF.Hardware;
using Microsoft.SPOT.Hardware;
using Robot.Micro.Core.Reactive;

namespace Robot.Micro.Core.Devices
{
    public class Joystick : Observable
    {
        private readonly AnalogIn _inputx;
        private readonly AnalogIn _inputy;
        private readonly InterruptPort _inputz;

        public PositionData Position { get { return new PositionData { X = _inputx.Read() / 1024.0, Y = _inputy.Read() / 1024.0 }; } }

        public Joystick(Cpu.Pin pinx, Cpu.Pin piny, Cpu.Pin pinz)
        {

            _inputx = new AnalogIn((AnalogIn.Pin) pinx);
            _inputx.SetLinearScale(0, 1024);
            _inputy = new AnalogIn((AnalogIn.Pin) piny);
            _inputy.SetLinearScale(0, 1024);
            _inputz = new InterruptPort(pinz, true, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
            _inputz.OnInterrupt += (data, state, time) => OnNext(new ButtonEvent(state, time));
        }

        public class PositionData
        {
            public double X;
            public double Y;
            public override string ToString()
            {
                return X + "," + Y;
            }
        }
    }
}
