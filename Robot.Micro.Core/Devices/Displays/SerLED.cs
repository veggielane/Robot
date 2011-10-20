using System;
using System.IO.Ports;
using Microsoft.SPOT;

namespace Robot.Micro.Core.Devices.Displays
{
    public class SerLED : SerialPort
    {
        public SerLED(String port, int baudRate)
            : base(port, baudRate)
        {
            throw Error.NotImplementedException();
        }
    }
}
