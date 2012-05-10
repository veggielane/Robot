using System;
using System.IO.Ports;
using System.Text;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Devices
{
    public class Serial : SerialPort
    {
        public Serial(string portName)
            : base(portName)
        {

        }

        public Serial(string portName, int baudRate)
            : base(portName, baudRate)
        {

        }

        public Serial(string portName, int baudRate, Parity parity)
            : base(portName, baudRate, parity)
        {

        }

        public Serial(string portName, int baudRate, Parity parity, int dataBits)
            : base(portName, baudRate, parity, dataBits)
        {

        }

        public Serial(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
            : base(portName, baudRate, parity, dataBits, stopBits)
        {

        }

        public void Write(Byte[] data)
        {
            Write(data, 0, data.Length);
        }

        public void Write(String data)
        {
            Write(Encoding.UTF8.GetBytes(data));
        }

        public void Write(Char data)
        {
            Write(data.ToString());
        }

    }
}
