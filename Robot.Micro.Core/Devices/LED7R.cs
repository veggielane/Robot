using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using GHIElectronics.OSH.NETMF.Hardware;

namespace Robot.Micro.Core.Devices
{
    public class LED7R
    {
        private readonly OutputPort[] _ports = new OutputPort[7];
        public LED7R(Cpu.Pin[] pins)
        {
            if(pins.Length != 7) throw new Exception("Wrong Number of Pins");

            for (int i = 0; i < 7; i++)
            {
                _ports[i] = new OutputPort(pins[i], false);
            }
        }

        public bool this[int i]
        {
            get { return _ports[i].Read(); }
            set { _ports[i].Write(value); }
        }
    }
}
