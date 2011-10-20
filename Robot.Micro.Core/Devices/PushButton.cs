using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Robot.Micro.Core.Devices
{
    public delegate void ButtonPressed(PushButton pushButton, ButtonState state);

    public enum ButtonState
    {
        Closed,
        Open
    }

    public class PushButton
    {
        private readonly InterruptPort _port;
        public ButtonPressed Pressed;

        public PushButton(Cpu.Pin pin)
        {
            _port = new InterruptPort(pin, true, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
            _port.OnInterrupt += _port_OnInterrupt;
        }

        private void _port_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            if (Pressed != null) Pressed(this, (ButtonState)data2);
        }
    }
}
