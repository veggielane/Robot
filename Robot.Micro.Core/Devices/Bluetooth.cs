using System;
using System.IO.Ports;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Devices
{
    public class Bluetooth:Serial
    {
        public Bluetooth(string portName)
            : base(portName)
        {

        }

        public Bluetooth(string portName, int baudRate)
            : base(portName, baudRate)
        {

        }

        public Bluetooth(string portName, int baudRate, Parity parity)
            : base(portName, baudRate, parity)
        {

        }

        public Bluetooth(string portName, int baudRate, Parity parity, int dataBits)
            : base(portName, baudRate, parity, dataBits)
        {

        }

        public Bluetooth(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
            : base(portName, baudRate, parity, dataBits, stopBits)
        {

        }
    }
}
