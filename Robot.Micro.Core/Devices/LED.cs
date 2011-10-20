using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Robot.Micro.Core.Devices
{
    public class LED
    {
        private readonly OutputPort _port;

        public bool State { 
            get { return _port.Read(); }
            set {_port.Write(value);} }

        public LED(Cpu.Pin pin):this(pin,false)
        {

        }

        public LED(Cpu.Pin pin, bool state)
        {
            _port = new OutputPort(pin, state);
        }
        public void Toggle()
        {
            State = !State;
        }
    }
}
